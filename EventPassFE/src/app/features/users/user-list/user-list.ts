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
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatChipsModule } from '@angular/material/chips';
import { MatTooltipModule } from '@angular/material/tooltip';
import { UserService } from '../../../core/services/user-service';
import { User } from '../../../core/models/user.model';

@Component({
  selector: 'app-user-list',
  standalone: true,
  templateUrl: './user-list.html',
  styleUrls: ['./user-list.css'],
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
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'surname', 'email', 'actions'];
  dataSource = new MatTableDataSource<User>([]);
  loading = false;

  filterControl = new FormControl('');

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private userService: UserService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadUsers();

    this.filterControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(value => this.applyFilter(value || ''));
  }

  ngAfterViewInit(): void {
    if (this.paginator) {
      this.dataSource.paginator = this.paginator;
    }

    if (this.sort) {
      this.dataSource.sort = this.sort;
    }
  }

  loadUsers(): void {
    this.loading = true;
    this.userService.getAllUsers().subscribe({
      next: users => {
        console.log('Loaded users:', users);
        console.log('First user structure:', users[0]);
        this.dataSource.data = users;

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
        this.snackBar.open('Error loading users.', 'OK', {
          duration: 3000
        });
      }
    });
  }

  applyFilter(value: string): void {
    this.dataSource.filter = value.trim().toLowerCase();
  }

  create(): void {
    this.router.navigate(['/users/create']);
  }

  edit(id: number): void {
    this.router.navigate([`/users/edit/${id}`]);
  }

  delete(id: number): void {
    console.log('Delete called with id:', id, 'type:', typeof id);
    
    if (!id) {
      this.snackBar.open('Invalid user ID', 'Close', { duration: 3000 });
      return;
    }

    if (confirm('Are you sure you want to delete this user?')) {
      this.userService.deleteUser(id).subscribe({
        next: () => {
          this.snackBar.open('User deleted successfully', 'Close', { duration: 3000 });
          this.loadUsers();
        },
        error: (err) => {
          console.error('Delete user error:', err);
          const errorMsg = err?.error?.message || err?.message || 'Error deleting user';
          this.snackBar.open(errorMsg, 'Close', { duration: 5000 });
        }
      });
    }
  }
}
