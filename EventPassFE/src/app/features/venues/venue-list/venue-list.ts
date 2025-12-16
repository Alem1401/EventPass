import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';

import { VenueResponseDto } from '../../../core/dtos/venue/venue-response.dto';
import { venueTypeDto } from '../../../core/dtos/venue/venue-type.dto';
import { createUpdateVenueDto } from '../../../core/dtos/venue/create-update-venue.dto.';
import { VenueService } from '../../../core/services/venue-service';


@Component({
  selector: 'app-venue-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MatTableModule,
    MatSnackBarModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatChipsModule,
    MatTooltipModule,
    MatSelectModule,
  ],
  templateUrl: './venue-list.html',
  styleUrls: ['./venue-list.css'],
})
export class VenueListComponent implements OnInit {
  displayedColumns: string[] = [
    'name',
    'location',
    'capacity',
    'type',
    'actions',
  ];
  dataSource = new MatTableDataSource<VenueResponseDto>([]);
  loading = true;
  filterControl = new FormControl('');

  
  editingRowId: number | null = null;
  editForms: { [key: number]: FormGroup } = {};
  venueTypes: venueTypeDto[] = [];

  constructor(
    private venueService: VenueService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadVenueTypes();
    this.loadVenues();
    this.setupFilter();
  }

  loadVenueTypes(): void {
    this.venueService.getVenueTypes().subscribe({
      next: (data) => {
        this.venueTypes = data;
      },
      error: () => {
        this.snackBar.open('Error loading venue types', 'Close', {
          duration: 3000,
        });
      },
    });
  }

  setupFilter(): void {
    this.filterControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe((value) => {
        this.applyFilter(value || '');
      });
  }

  applyFilter(filterValue: string): void {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  loadVenues(): void {
    this.loading = true;
    this.venueService.getAllVenues().subscribe({
      next: (venues) => {
        this.dataSource.data = venues;

        venues.forEach((venue) => {
          const venueTypeId = this.mapVenueTypeToID(venue.venueType);
          this.editForms[venue.id] = new FormGroup({
            name: new FormControl(venue.name, [Validators.required]),
            city: new FormControl(venue.city, [Validators.required]),
            country: new FormControl(venue.country, [Validators.required]),
            capacity: new FormControl(venue.capacity, [
              Validators.required,
              Validators.min(1),
            ]),
            venueTypeID: new FormControl(venueTypeId, [Validators.required]),
          });
        });
        this.loading = false;
      },
      error: () => {
        this.snackBar.open('Error loading venues', 'Close', { duration: 3000 });
        this.loading = false;
      },
    });
  }

  createVenue(): void {
    this.router.navigate(['/admin/venues/create']);
  }

  editVenue(id: number): void {
    this.router.navigate(['/admin/venues/edit', id]);
  }

  deleteVenue(id: number): void {
    if (confirm('Are you sure you want to delete this venue?')) {
      this.venueService.deleteVenue(id).subscribe({
        next: () => {
          this.snackBar.open('Venue deleted successfully', 'Close', {
            duration: 3000,
          });
          this.loadVenues();
        },
        error: () => {
          this.snackBar.open('Error deleting venue', 'Close', {
            duration: 3000,
          });
        },
      });
    }
  }

  isEditing(venueId: number): boolean {
    return this.editingRowId === venueId;
  }

  startQuickEdit(venue: VenueResponseDto): void {
    this.editingRowId = venue.id;
  }

  saveQuickEdit(venue: VenueResponseDto): void {
    if (this.editingRowId) {
      const form = this.editForms[this.editingRowId];

      if (form.invalid) {
        this.snackBar.open('Please fill in all required fields correctly', 'Close', {
          duration: 3000,
        });
        return;
      }

      const toUpdate: createUpdateVenueDto = {
        name: form.controls['name'].value,
        adress: venue.adress,
        city: form.controls['city'].value,
        country: form.controls['country'].value,
        postalCode: venue.postalCode,
        capacity: Number(form.controls['capacity'].value),
        venueTypeID: Number(form.controls['venueTypeID'].value),
      };

      console.log('Sending update data:', toUpdate);

      this.venueService.updateVenue(toUpdate,venue.id).subscribe({
        next: () => {
          this.snackBar.open('Venue updated successfully', 'Close', {
            duration: 3000,
          });
          this.editingRowId = null;
          this.loadVenues();
        },
        error: (error) => {
          console.error('Update error:', error);
          this.snackBar.open('Error updating venue', 'Close', {
            duration: 3000,
          });
        },
      });



     
    }
  }

  cancelEdit(): void {
    this.editingRowId = null;
  }

  private mapVenueTypeToID(venueTypeName: string): number {
    const venueType = this.venueTypes.find((t) => t.name === venueTypeName);
    if (venueType) {
      return venueType.id;
    }
    return 1;
  }
}
