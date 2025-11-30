import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';

import { EventService } from '../../../../app/core/services/event-service';
import { EventCreate, EventUpdate } from '../../../../app/core/models/event.model';

import { PerformerService } from '../../../core/services/performer-service';
import { OrganizerService } from '../../../core/services/organizer-service';
import { CategoryService } from '../../../core/services/category-service';
import { VenueService } from '../../../core/services/venue-service';

import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-event-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatSnackBarModule
  ],
  templateUrl: './event-form.html',
  styleUrls: ['./event-form.css']
})
export class EventFormComponent implements OnInit {

  eventForm: FormGroup;
  isEditMode = false;
  eventId: number | null = null;
  isLoading = false;

  performers: any[] = [];
  categories: any[] = [];
  organizers: any[] = [];
  venues: any[] = [];
  loadingDropdowns = false;

  constructor(
    private fb: FormBuilder,
    private eventService: EventService,
    private performerService: PerformerService,
    private categoryService: CategoryService,
    private organizerService: OrganizerService,
    private venueService: VenueService,
    private snackBar: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.eventForm = this.createForm();
  }

  ngOnInit(): void {
    this.isLoading = true;

    this.loadDropdownData().then(() => {
      const id = this.route.snapshot.paramMap.get('id');

      if (id) {
        this.isEditMode = true;
        this.eventId = +id;
        this.loadEvent(this.eventId);
      } else {
        this.isLoading = false;
      }
    });
  }

  async loadDropdownData(): Promise<void> {
    this.loadingDropdowns = true;

    try {
      const performers = await firstValueFrom(this.performerService.getAll());
      const categories = await firstValueFrom(this.categoryService.getAll());
      const organizers = await firstValueFrom(this.organizerService.getAll());
      const venues = await firstValueFrom(this.venueService.getAllVenues());

      this.performers = performers ?? [];
      this.categories = categories ?? [];
      this.organizers = organizers ?? [];
      this.venues = venues ?? [];

    } catch {
      this.snackBar.open("Error loading dropdown data.", "OK", { duration: 3000 });
    }

    this.loadingDropdowns = false;
  }

  createForm(): FormGroup {
    return this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      bannerURL: ['', [Validators.pattern('https?://.+')]],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      duration: ['', Validators.required],
      minimumAge: [0, [Validators.min(0), Validators.max(100)]],
      performerID: [null, [Validators.required]],
      categoryId: [null, [Validators.required]],
      organizerID: [null, [Validators.required]],
      venueID: [null, [Validators.required]]
    });
  }

  loadEvent(id: number): void {
    this.isLoading = true;
    this.eventService.getEventById(id).subscribe({
      next: (event) => {
        // Patch basic fields first
        this.eventForm.patchValue({
          name: event.name,
          description: event.description,
          bannerURL: event.bannerURL,
          startDate: new Date(event.startDate),
          endDate: new Date(event.endDate),
          duration: event.duration,
          minimumAge: event.minimumAge,
          performerID: event.performerID ?? event.performerID ?? null,
          categoryId: event.categoryId ?? event.categoryId ?? null,
          organizerID: event.organizerID ?? event.organizerID ?? null
        });

        // Ensure venue control is set even if backend uses different property name
        const venueIdFromResponse = (event as any).venueID ?? (event as any).venueId ?? (event as any).venue?.id ?? null;
        console.log('loadEvent: resolved venueIdFromResponse =', venueIdFromResponse);
        if (venueIdFromResponse !== null && venueIdFromResponse !== undefined) {
          this.eventForm.get('venueID')?.setValue(Number(venueIdFromResponse));
        }
        this.isLoading = false;
      },
      error: () => {
        this.snackBar.open('Error loading event', 'Close', { duration: 3000 });
        this.isLoading = false;
      }
    });
  }

  onSubmit(): void {
    if (!this.eventForm.valid) {
      this.markFormGroupTouched();
      return;
    }

    this.isLoading = true;
    console.log('onSubmit: Form is valid, preparing data...');
    const formValue = this.prepareFormData();
    console.log('onSubmit: Form data prepared:', formValue);

    if (this.isEditMode && this.eventId) {
      console.log('onSubmit: Updating event', this.eventId);
      this.updateEvent(formValue);
    } else {
      console.log('onSubmit: Creating new event');
      this.createEvent(formValue);
    }
  }

  private prepareFormData(): EventCreate {
    const formValue = this.eventForm.value;

    console.log('DEBUG: formValue.venueID raw:', formValue.venueID, 'type:', typeof formValue.venueID);
    console.log('DEBUG: venueID form control:', this.eventForm.get('venueID')?.value);
    console.log('DEBUG: venues array:', this.venues);

    let durationWithSec = formValue.duration;
    if (/^\d{1,2}:\d{2}$/.test(durationWithSec)) durationWithSec += ':00';

    const eventData: EventCreate = {
      name: formValue.name,
      description: formValue.description,
      bannerURL: formValue.bannerURL,
      startDate: new Date(formValue.startDate).toISOString(),
      endDate: new Date(formValue.endDate).toISOString(),
      duration: durationWithSec,
      minimumAge: formValue.minimumAge,
      performerID: Number(formValue.performerID),
      categoryId: Number(formValue.categoryId),
      organizerID: Number(formValue.organizerID),
      venueID: Number(formValue.venueID)
    };

    console.log('prepareFormData result:', JSON.stringify(eventData, null, 2));
    console.log('performerID type:', typeof eventData.performerID, 'value:', eventData.performerID);
    console.log('categoryId type:', typeof eventData.categoryId, 'value:', eventData.categoryId);
    console.log('organizerID type:', typeof eventData.organizerID, 'value:', eventData.organizerID);
    console.log('venueID type:', typeof eventData.venueID, 'value:', eventData.venueID);

    return eventData;
  }

  onVenueSelection(event: any): void {
    console.log('mat-select selectionChange (venue):', event);
  }

  onPerformerChange(event: any): void {
    console.log('onPerformerChange:', event.value, 'type:', typeof event.value);
    this.eventForm.get('performerID')?.setValue(Number(event.value));
  }

  onCategoryChange(event: any): void {
    console.log('onCategoryChange:', event.value, 'type:', typeof event.value);
    this.eventForm.get('categoryId')?.setValue(Number(event.value));
  }

  onOrganizerChange(event: any): void {
    console.log('onOrganizerChange:', event.value, 'type:', typeof event.value);
    this.eventForm.get('organizerID')?.setValue(Number(event.value));
  }

  onVenueChange(event: any): void {
    console.log('onVenueChange:', event.value, 'type:', typeof event.value);
    this.eventForm.get('venueID')?.setValue(Number(event.value));
  }

  private createEvent(eventData: EventCreate): void {
    console.log('createEvent called with:', eventData);
    this.eventService.createEvent(eventData).subscribe({
      next: () => {
        console.log('createEvent: SUCCESS');
        this.isLoading = false;
        this.snackBar.open('Event created successfully!', 'Close', { duration: 3000 });
        this.router.navigate(['/events']);
      },
      error: (err) => {
        console.log('createEvent: ERROR', err);
        console.log('ERROR STATUS:', err.status);
        console.log('ERROR MESSAGE:', err.message);
        console.log('ERROR BODY:', err.error);
        this.isLoading = false;
        this.snackBar.open('Error creating event: ' + (err.error?.message || err.message || 'Unknown error'), 'Close', { duration: 5000 });
      }
    });
  }

  private updateEvent(eventData: EventUpdate): void {
    if (!this.eventId) return;

    console.log('updateEvent called with eventId:', this.eventId, 'data:', eventData);
    this.eventService.updateEvent(this.eventId, eventData).subscribe({
      next: () => {
        console.log('updateEvent: SUCCESS');
        this.snackBar.open('Event updated successfully!', 'Close', { duration: 3000 });
        this.router.navigate(['/events']);
      },
      error: (err) => {
        console.log('updateEvent: ERROR', err);
        this.isLoading = false;
        this.snackBar.open('Error updating event', 'Close', { duration: 3000 });
      }
    });
  }

  private markFormGroupTouched(): void {
    Object.values(this.eventForm.controls).forEach(control => {
      control.markAsTouched();
    });
  }

  getErrorMessage(controlName: string): string {
    const control = this.eventForm.get(controlName);
    if (!control?.errors) return '';

    if (control.errors['required']) return 'This field is required';
    if (control.errors['maxlength']) return 'Maximum length exceeded';
    if (control.errors['min']) return 'Value too small';
    if (control.errors['max']) return 'Value too large';
    if (control.errors['pattern']) return 'Invalid URL format';

    return '';
  }

  goBack(): void {
    this.router.navigate(['/events']);
  }
}
