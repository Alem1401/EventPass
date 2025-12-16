import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { responseSectionDto } from '../../../core/dtos/venue/response-section.dto';

@Component({
  selector: 'app-section-table',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
  ],
  templateUrl: './section-table.html',
  styleUrls: ['./section-table.css'],
})
export class SectionTable implements OnChanges {
  @Input() sections: responseSectionDto[] = [];
  @Output() removeSection = new EventEmitter<responseSectionDto>();
  @Output() finishUpdating = new EventEmitter<{
    id: number;
    oldName: string;
    newName: string;
    oldCapacity: number;
    newCapacity: number;
  }>();

  // Inline editing properties
  editingRowId: number | null = null;
  editForms: { [key: number]: FormGroup } = {};

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['sections'] && this.sections) {
      this.initializeEditForms();
    }
  }

  initializeEditForms(): void {
    this.sections.forEach((section) => {
      this.editForms[section.id] = new FormGroup({
        name: new FormControl(section.name, [Validators.required]),
        capacity: new FormControl(section.capacity, [
          Validators.required,
          Validators.min(1),
        ]),
      });
    });
  }

  isEditing(sectionId: number): boolean {
    return this.editingRowId === sectionId;
  }

  startQuickEdit(section: responseSectionDto): void {
    this.editingRowId = section.id;
  }

  saveQuickEdit(section: responseSectionDto): void {
    if (this.editingRowId) {
      const form = this.editForms[this.editingRowId];

      if (form.invalid) {
        return;
      }

      const toUpdate = {
        id: section.id,
        oldName: section.name,
        newName: form.controls['name'].value,
        oldCapacity: section.capacity,
        newCapacity: Number(form.controls['capacity'].value),
      };

      this.finishUpdating.emit(toUpdate);
      this.editingRowId = null;
    }
  }

  cancelEdit(): void {
    
    if (this.editingRowId) {
      const section = this.sections.find((s) => s.id === this.editingRowId);
      if (section) {
        this.editForms[this.editingRowId].patchValue({
          name: section.name,
          capacity: section.capacity,
        });
      }
    }
    this.editingRowId = null;
  }

  deleteSection(toDelete: responseSectionDto): void {
    this.removeSection.emit(toDelete);
  }
}
