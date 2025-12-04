import { Component,Output,EventEmitter,Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatError } from '@angular/material/form-field';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Validator } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { responseSectionDto } from '../../../core/dtos/venue/response-section.dto';


@Component({
  selector: 'app-section-form',
  imports: [MatCardModule, MatInputModule, MatFormFieldModule, MatError, ReactiveFormsModule, MatIconModule, MatButtonModule],
  templateUrl: './section-form.html',
  styleUrl: './section-form.css',
})
export class SectionForm implements OnChanges{

  ngOnChanges(): void {
    if (this.sectionToUpdate != null) {
      this.sectionForm.controls.name.setValue(this.sectionToUpdate.name);
      this.sectionForm.controls.capacity.setValue(this.sectionToUpdate.capacity);
    }
    console.log(this.sectionToUpdate);
  }

  sectionForm = new FormGroup({
    name : new FormControl("",{validators: Validators.required}),
    capacity : new FormControl(1,{validators: [Validators.required, Validators.min(1)]}),
  })

  @Output() toBeAdded = new EventEmitter<{name :string ,capacity: number}>();
  @Output() toBeUpdated = new EventEmitter<{
    id: number;
    oldName: string;
    newName: string;
    oldCapacity: number;
    newCapacity: number;
  }>();
  @Input() sectionToUpdate : responseSectionDto | null = null;


  submitSection() {
    if (this.sectionToUpdate == null) {
      const newSection: { name: string; capacity: number } = {
        name: this.sectionForm.controls.name.value || "",
        capacity: this.sectionForm.controls.capacity.value || 1,
      };
      this.toBeAdded.emit(newSection);
    } else {
      const updatedSection = {
        id: this.sectionToUpdate.id,
        oldName: this.sectionToUpdate.name,
        newName: this.sectionForm.controls.name.value || "",
        oldCapacity: this.sectionToUpdate.capacity,
        newCapacity: this.sectionForm.controls.capacity.value || 1,
      };
      this.toBeUpdated.emit(updatedSection);
    }
  }

}
