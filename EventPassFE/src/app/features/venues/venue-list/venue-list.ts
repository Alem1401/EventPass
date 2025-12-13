import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
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

import { VenueResponseDto } from '../../../core/dtos/venue/venue-response.dto';
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
    MatTooltipModule
  ],
  templateUrl: './venue-list.html',
  styleUrls: ['./venue-list.css']
})
export class VenueListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'location', 'capacity', 'type', 'actions'];
  dataSource = new MatTableDataSource<VenueResponseDto>([]);
  loading = true;
  filterControl = new FormControl('');

  constructor(
    private venueService: VenueService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadVenues();
    this.setupFilter();
  }

  setupFilter(): void {
    this.filterControl.valueChanges
      .pipe(
        debounceTime(300),
        distinctUntilChanged()
      )
      .subscribe(value => {
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
        this.loading = false;
      },
      error: () => {
        this.snackBar.open('Error loading venues', 'Close', { duration: 3000 });
        this.loading = false;
      }
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
            
          this.snackBar.open('Venue deleted successfully', 'Close', { duration: 3000 });
          this.loadVenues();
        },
        error: () => {
          this.snackBar.open('Error deleting venue', 'Close', { duration: 3000 });
        }
      });
    }
  }
}
