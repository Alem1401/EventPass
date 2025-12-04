import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { CreatePerformerDto } from '../../../core/dtos/performers/CreatePerformerDto';
import { UpdatePerformerDto } from '../../../core/dtos/performers/UpdatePerformerDto';
import { Performer } from '../../../core/models/performer.model';
import { PerformerService } from '../../../core/services/performer-service';
import { UpdateSocialMediaDto } from '../../../core/dtos/performers/UpdateSocialMediaDto';

const urlPattern =
  /^(https?:\/\/)([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(\/[^\s]*)?$/;

@Component({
  selector: 'app-performer-form',
  standalone: true,
  templateUrl: './performer-form.html',
  styleUrls: ['./performer-form.css'],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
    MatDividerModule,
    MatTooltipModule
  ]
})
export class PerformerFormComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitting = false;
  isEditMode = false;
  performerId?: number;

  constructor(
    private fb: FormBuilder,
    private performerService: PerformerService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.buildForm();
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.isEditMode = true;
      this.performerId = +idParam;
      this.loadPerformer(this.performerId);
    }
  }

  buildForm(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      imageURL: ['', [Validators.required, Validators.pattern(urlPattern)]],
      website: ['', [Validators.pattern(urlPattern)]],
      socialMedia: this.fb.array([])
    });
  }

  get socialMedia(): FormArray {
    return this.form.get('socialMedia') as FormArray;
  }

  addSocialLink(value: string = '', id?: number | null): void {
    const group = this.fb.group({
      id: new FormControl(id ?? null),
      link: new FormControl(value, [
        Validators.required,
        Validators.pattern(urlPattern)
      ])
    });

    this.socialMedia.push(group);
  }

  removeSocialLink(index: number): void {
    this.socialMedia.removeAt(index);
  }

  loadPerformer(id: number): void {
    this.loading = true;
    this.performerService.getById(id).subscribe({
      next: (performer: Performer) => {
        this.form.patchValue({
          name: performer.name,
          imageURL: performer.imageURL,
          website: performer.website
        });

        this.socialMedia.clear();
        performer.socialMedia?.forEach(sm =>
          this.addSocialLink(sm.link, sm.id)
        );

        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.snackBar.open('Error while loading performer.', 'OK', {
          duration: 3000
        });
        this.router.navigate(['/performers']);
      }
    });
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.snackBar.open('Please fill in the form correctly.', 'OK', {
        duration: 2500
      });
      return;
    }

    this.submitting = true;

    if (this.isEditMode && this.performerId != null) {
      const updateDto: UpdatePerformerDto = {
        name: this.form.value.name,
        imageURL: this.form.value.imageURL,
        website: this.form.value.website,
        socialMedia: this.form.value.socialMedia.map(
          (sm: UpdateSocialMediaDto) => ({
            id: sm.id ?? null,
            link: sm.link
          })
        )
      };

      this.performerService.update(this.performerId, updateDto).subscribe({
        next: () => {
          this.submitting = false;
          this.snackBar.open('Performer updated successfully.', 'OK', {
            duration: 2500
          });
          this.router.navigate(['/performers']);
        },
        error: () => {
          this.submitting = false;
          this.snackBar.open('Error while updating performer.', 'OK', {
            duration: 3000
          });
        }
      });
    } else {
      const createDto: CreatePerformerDto = {
        name: this.form.value.name,
        imageURL: this.form.value.imageURL,
        website: this.form.value.website,
        socialMedia: this.form.value.socialMedia.map((sm: { link: string }) => ({
          link: sm.link
        }))
      };

      this.performerService.create(createDto).subscribe({
        next: () => {
          this.submitting = false;
          this.snackBar.open('Performer created successfully.', 'OK', {
            duration: 2500
          });
          this.router.navigate(['/performers']);
        },
        error: () => {
          this.submitting = false;
          this.snackBar.open('Error while creating performer.', 'OK', {
            duration: 3000
          });
        }
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/performers']);
  }
}
