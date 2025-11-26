import { Component, inject, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatSelect, MatOption } from '@angular/material/select';
import { venueTypeDto } from '../../../core/dtos/venue/venue-type.dto';
import { VenueService } from '../../../core/services/venue-service';
import { createUpdateVenueDto } from '../../../core/dtos/venue/create-update-venue.dto.';
import { VenueResponseDto } from '../../../core/dtos/venue/venue-response.dto';
import { ActivatedRoute, Router } from '@angular/router';
import { SectionForm } from '../section-form/section-form';
import { createSectionDto } from '../../../core/dtos/venue/create-section.dto';
import { responseSectionDto } from '../../../core/dtos/venue/response-section.dto';
import { SectionTable } from '../section-table/section-table';
@Component({
  selector: 'app-venue-form',
  imports: [
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    CommonModule,
    MatSelect,
    MatOption,
    SectionForm,
    SectionTable,
  ],
  templateUrl: './venue-form.html',
  styleUrl: './venue-form.css',
})
export class VenueForm implements OnInit {
  venueForm = new FormGroup({
    name: new FormControl('', { validators: Validators.required }),
    address: new FormControl('', { validators: Validators.required }),
    city: new FormControl('', { validators: Validators.required }),
    country: new FormControl('', { validators: Validators.required }),
    postalCode: new FormControl(1, {
      validators: [Validators.required, Validators.min(1)],
    }),
    capacity: new FormControl(1, {
      validators: [Validators.required, Validators.min(1)],
    }),
    venueTypeID: new FormControl(1, {
      validators: [Validators.min(1), Validators.required],
    }),
  });

  venueService = inject(VenueService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  venueTypes: venueTypeDto[] = [];
  editMode: boolean = false;
  venueId: number | null = null;
  showSectionForm = false;
  showSectionTable = false;

  ngOnInit(): void {
    this.loadVenueTypes();
    this.venueService.getAllVenues().subscribe({});
  }

  loadVenueTypes() {
    this.venueService.getVenueTypes().subscribe({
      next: (data) => {
        this.venueTypes = data;
        this.initializeVenueForm();
      },
      error: (err) => {
        console.error('Error loading venue types:', err);
        this.initializeVenueForm();
      },
    });
  }

  initializeVenueForm() {
    this.route.params.subscribe((params) => {
      const id = params['id'];

      if (id) {
        this.venueId = Number(id);
        this.editMode = true;

        this.loadVenue(this.venueId);
      } else {
        this.editMode = false;
        this.venueId = null;
        this.venueForm.reset();
      }
    });
  }

  existingSections: responseSectionDto[] = [];

  displayedSections: responseSectionDto[] = [];

  loadVenue(id: number) {
    this.venueService.getVenueById(id).subscribe({
      next: (data: VenueResponseDto) => {
        const venueTypeID = this.mapVenueTypeToID(data.venueType);

        this.venueService.getSectionsByVenue(id).subscribe({
          next: (sectionsData) => {
            this.existingSections = sectionsData;
            this.displayedSections = [...sectionsData];
          },
        });
        this.venueForm.patchValue({
          name: data.name,
          address: data.address,
          city: data.city,
          country: data.country,
          postalCode: data.postalCode,
          capacity: data.capacity,
          venueTypeID: venueTypeID,
        });
        console.log('Form patched with values:', this.venueForm.value);
      },
      error: (err) => {
        console.error('Error loading venue:', err);
        console.error('Error status:', err.status);
        console.error('Error URL:', err.url);

        if (err.status === 404) {
          alert(`Venue with ID ${id} not found!`);
          this.router.navigate(['/venues/create']);
        }
      },
    });
  }

  private mapVenueTypeToID(venueTypeName: string): number {
    const venueType = this.venueTypes.find((t) => t.name === venueTypeName);
    if (venueType) {
      return venueType.id;
    }

    console.warn('Venue type not found, using default ID 1');
    return 1;
  }

  private newSections: { name: string; capacity: number }[] = [];

  addSection(newSection: { name: string; capacity: number }) {
    console.log('New section to be added:', newSection);
    this.newSections.push(newSection);
    this.displayedSections.push({
      name: newSection.name,
      capacity: newSection.capacity,
      id: -1,
    });
    console.log('All sections:', this.newSections);
  }

  isFormValid(): boolean {
    return this.venueForm.valid;
  }

  finishVenue() {
    if (this.isFormValid()) {
      const venueData: createUpdateVenueDto = {
        name: this.venueForm.controls.name.value || '',
        adress: this.venueForm.controls.address.value || '',
        city: this.venueForm.controls.city.value || '',
        country: this.venueForm.controls.country.value || '',
        postalCode: this.venueForm.controls.postalCode.value || 1,
        capacity: this.venueForm.controls.capacity.value || 1,
        venueTypeID: this.venueForm.controls.venueTypeID.value || 1,
      };

      console.log(this.venueForm.value.venueTypeID);
      console.log('Submitting venue data:', venueData);

      if (this.editMode && this.venueId) {
        this.venueService.updateVenue(venueData, this.venueId).subscribe({
          next: () => {
            console.log('Venue updated successfully');
            if (this.newSections.length > 0) {
              for (const section of this.newSections) {
                const sectionDto: createSectionDto = {
                  name: section.name,
                  capacity: section.capacity,
                  venueID: Number(this.venueId),
                };
                this.venueService.addSectiontoVenue(sectionDto).subscribe({
                  next: () => console.log('section added'),
                });
              }
            }
          },
          error: (err) => {
            console.error('Error updating venue:', err);
          },
        });
      } else {
        this.venueService.addVenue(venueData).subscribe({
          next: (response) => {
            console.log('added venue with id ' + response);
            console.log('Venue added successfully');
            for (const section of this.newSections) {
              const sectionDto: createSectionDto = {
                name: section.name,
                capacity: section.capacity,
                venueID: Number(response),
              };
              this.venueService.addSectiontoVenue(sectionDto).subscribe({
                next: (data) => {
                  console.log('Section added successfully' + data);
                },
              });
            }
          },
          error: (err) => {
            console.error('Error adding venue:', err);
          },
        });
      }
    } else {
      console.log('Form is invalid, please check the fields');
      console.log('Form errors:', this.venueForm.errors);
      console.log('Form controls status:', this.venueForm.status);

      Object.keys(this.venueForm.controls).forEach((key) => {
        const control = this.venueForm.get(key);
        if (control && control.invalid) {
          console.log(`Field ${key} is invalid:`, control.errors);
        }
      });
    }
  }

  toggleSectionForm(): void {
    if (this.showSectionTable) {
      this.showSectionTable = false;
    }
    this.showSectionForm = !this.showSectionForm;
  }

  toggleSectionTable(): void {
    if (this.showSectionForm) {
      this.showSectionForm = false;
    }
    this.showSectionTable = !this.showSectionTable;
  }

  deleteSection(toDelete: responseSectionDto): void {
    if (toDelete.id < 0) {
      const indexDisplay = this.displayedSections.findIndex(
        (i) => i.capacity == toDelete.capacity && i.name == toDelete.name
      );
      this.displayedSections.splice(indexDisplay, 1);
      const indexAdd = this.newSections.findIndex(
        (i) => i.capacity == toDelete.capacity && i.name == toDelete.name
      );
      this.newSections.splice(indexAdd, 1);
    }
    if (toDelete.id > 0) {
      const indexDisplay = this.displayedSections.findIndex(
        (i) => i.id == toDelete.id
      );
      this.displayedSections.splice(indexDisplay, 1);
      this.venueService.deleteSection(toDelete.id).subscribe();
    }
  }

  updateSection(updatedSection: {
    id: number;
    oldName: string;
    newName: string;
    oldCapacity: number;
    newCapacity: number;
  }): void {
    console.log('Updating section:', updatedSection);
    if (updatedSection.id < 0) {
      const index = this.newSections.findIndex(
        (s) =>
          s.name === updatedSection.oldName &&
          s.capacity == updatedSection.oldCapacity
      );
      if (index >= 0) {
        this.newSections[index] = {
          name: updatedSection.newName,
          capacity: updatedSection.newCapacity,
        };
      } else {
        console.warn(
          `Section with old name '${updatedSection.oldName}' not found in newSections.`
        );
      }
    } else {
      const index = this.displayedSections.findIndex(
        (s) => s.id === updatedSection.id
      );
      if (index >= 0) {
        this.displayedSections[index] = {
          ...this.displayedSections[index],
          name: updatedSection.newName,
          capacity: updatedSection.newCapacity,
        };
      } else {
        console.warn(
          `Section with ID '${updatedSection.id}' not found in displayedSections.`
        );
      }

      this.venueService
        .updateSection({
          id: updatedSection.id,
          name: updatedSection.newName,
          capacity: updatedSection.newCapacity,
        })
        .subscribe({
          next: () =>
            console.log(
              `Section with ID ${updatedSection.id} updated successfully`
            ),
          error: (err: any) =>
            console.error(
              `Error updating section with ID ${updatedSection.id}:`,
              err
            ),
        });
    }
  }
}
