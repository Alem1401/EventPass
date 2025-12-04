import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { PerformerService } from '../../../core/services/performer-service';
import { Performer } from '../../../core/models/performer.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatChipsModule } from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-performer-list',
  standalone: true,
  templateUrl: './performer-list.html',
  styleUrls: ['./performer-list.css'],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatTooltipModule
  ]
})
export class PerformerListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'website', 'socialCount', 'actions'];
  dataSource = new MatTableDataSource<Performer>([]);
  loading = false;

  filterControl = new FormControl('');

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private performerService: PerformerService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadPerformers();

    this.filterControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(value => this.applyFilter(value || ''));
  }

  loadPerformers(): void {
    this.loading = true;
    this.performerService.getAll().subscribe({
      next: performers => {
        this.dataSource = new MatTableDataSource(performers);

        if (this.paginator) {
          this.dataSource.paginator = this.paginator;
        }

        if (this.sort) {
          this.dataSource.sort = this.sort;
        }

        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.snackBar.open('Error loading performers.', 'OK', {
          duration: 3000
        });
      }
    });
  }

  applyFilter(value: string): void {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['/performers/create']);
  }

  edit(row: Performer): void {
    this.router.navigate(['/performers/edit', row.id]);
  }

  delete(row: Performer): void {
    const confirmed = window.confirm(
      `Are you sure you want to delete performer "${row.name}"?`
    );

    if (!confirmed) return;

    this.loading = true;

    this.performerService.delete(row.id).subscribe({
      next: () => {
        this.snackBar.open('Performer deleted successfully.', 'OK', {
          duration: 2500
        });
        this.loadPerformers();
      },
      error: () => {
        this.loading = false;
        this.snackBar.open('Error deleting performer.', 'OK', {
          duration: 3000
        });
      }
    });
  }

  getSocialCount(row: Performer): number {
    return row.socialMedia?.length ?? 0;
  }
}
