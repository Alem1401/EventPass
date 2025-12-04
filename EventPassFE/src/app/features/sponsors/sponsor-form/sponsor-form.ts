import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDividerModule } from '@angular/material/divider';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { SponsorService } from '../../../core/services/sponsor-service';
import { SponsorCreate } from '../../../core/models/sponsor.model';

@Component({
  selector: 'app-sponsor-form',
  templateUrl: './sponsor-form.html',
  styleUrls: ['./sponsor-form.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    MatDividerModule,
  ],
})
export class SponsorFormComponent implements OnInit {

  router = inject(Router);
  route = inject(ActivatedRoute);
  sponsorService = inject(SponsorService);
  snackBar = inject(MatSnackBar);

  isLoading = false;
  isEditMode = false;
  editingId: number | null = null;

  sponsorForm = new FormGroup({
    Name: new FormControl('', Validators.required),
    LogoUrl: new FormControl('', Validators.required),
    websiteUrl: new FormControl('', [
      Validators.required,
      Validators.pattern(/^https?:\/\/.+$/)
    ]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Phone: new FormControl('', Validators.required),
  });

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.isEditMode = true;
      this.editingId = Number(id);
      this.loadSponsor(this.editingId);
    }
  }

  loadSponsor(id: number) {
    this.isLoading = true;

    this.sponsorService.getSponsorById(id).subscribe({
      next: (s) => {
        this.sponsorForm.patchValue({
          Name: s.name,
          LogoUrl: s.logoUrl,
          websiteUrl: s.websiteUrl,
          Email: s.email,
          Phone: s.phone
        });

        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

  getErrorMessage(controlName: string) {
    const control = this.sponsorForm.get(controlName);
    if (!control || !control.touched) return '';

    if (control.hasError('required')) return 'This field is required';
    if (control.hasError('email')) return 'Invalid email format';
    if (control.hasError('pattern')) return 'Invalid format';

    return '';
  }

  onSubmit() {
    if (this.sponsorForm.invalid) return;

    const payload: SponsorCreate = this.sponsorForm.value as SponsorCreate;

    if (this.isEditMode && this.editingId) {
      this.sponsorService.updateSponsor(this.editingId, payload).subscribe({
        next: () => {
          this.snackBar.open('Sponsor updated!', 'OK', { duration: 2000 });
          this.router.navigate(['/sponsors']);
        }
      });
    } else {
      this.sponsorService.createSponsor(payload).subscribe({
        next: () => {
          this.snackBar.open('Sponsor created!', 'OK', { duration: 2000 });
          this.router.navigate(['/sponsors']);
        }
      });
    }
  }


  goBack() {
    this.router.navigate(['/sponsors']);
  }
}
