import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { Event } from '../../../core/models/event.model';
import { EventService } from '../../../core/services/event-service';

@Component({
  selector: 'app-event-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatSnackBarModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './event-list.html',
  styleUrls: ['./event-list.css']
})
export class EventListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'startDate', 'endDate', 'category', 'organizer', 'actions'];
  dataSource = new MatTableDataSource<Event>();
  isLoading = true;

  constructor(
    private eventService: EventService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.isLoading = true;
    this.eventService.getAllEvents().subscribe({
      next: (events) => {
        this.dataSource.data = events;
        this.isLoading = false;
      },
      error: () => {
        this.snackBar.open('Error loading events', 'Close', { duration: 3000 });
        this.isLoading = false;
      }
    });
  }

  deleteEvent(id: number): void {
    if (confirm('Are you sure you want to delete this event?')) {
      this.eventService.deleteEvent(id).subscribe({
        next: () => {
          this.snackBar.open('Event deleted successfully', 'Close', { duration: 3000 });
          this.loadEvents();
        },
        error: () => {
          this.snackBar.open('Error deleting event', 'Close', { duration: 3000 });
        }
      });
    }
  }

  applyFilter(e: KeyboardEvent): void {
    const filterValue = (e.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
