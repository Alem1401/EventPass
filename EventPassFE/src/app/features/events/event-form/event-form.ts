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
  loadingDropdowns = false;

  constructor(
    private fb: FormBuilder,
    private eventService: EventService,
    private performerService: PerformerService,
    private categoryService: CategoryService,
    private organizerService: OrganizerService,
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

      this.performers = performers ?? [];
      this.categories = categories ?? [];
      this.organizers = organizers ?? [];

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
      performerID: ['', [Validators.required]],
      categoryId: ['', [Validators.required]],
      organizerID: ['', [Validators.required]]
    });
  }

  loadEvent(id: number): void {
    this.isLoading = true;
    this.eventService.getEventById(id).subscribe({
      next: (event) => {
        this.eventForm.patchValue({
          ...event,
          startDate: new Date(event.startDate),
          endDate: new Date(event.endDate)
        });
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
    const formValue = this.prepareFormData();

    if (this.isEditMode && this.eventId) {
      this.updateEvent(formValue);
    } else {
      this.createEvent(formValue);
    }
  }

  private prepareFormData(): EventCreate {
    const formValue = this.eventForm.value;

    let durationWithSec = formValue.duration;
    if (/^\d{1,2}:\d{2}$/.test(durationWithSec)) durationWithSec += ':00';

    return {
      name: formValue.name,
      description: formValue.description,
      bannerURL: formValue.bannerURL,
      startDate: new Date(formValue.startDate).toISOString(),
      endDate: new Date(formValue.endDate).toISOString(),
      duration: durationWithSec,
      minimumAge: formValue.minimumAge,
      performerID: formValue.performerID,
      categoryId: formValue.categoryId,
      organizerID: formValue.organizerID
    };
  }

  private createEvent(eventData: EventCreate): void {
    this.eventService.createEvent(eventData).subscribe({
      next: () => {
        this.isLoading = false;
        this.snackBar.open('Event created successfully!', 'Close', { duration: 3000 });
        this.router.navigate(['/events']);
      },
      error: () => {
        this.isLoading = false;
        this.snackBar.open('Error creating event', 'Close', { duration: 3000 });
      }
    });
  }

  private updateEvent(eventData: EventUpdate): void {
    if (!this.eventId) return;

    this.eventService.updateEvent(this.eventId, eventData).subscribe({
      next: () => {
        this.snackBar.open('Event updated successfully!', 'Close', { duration: 3000 });
        this.router.navigate(['/events']);
      },
      error: () => {
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
