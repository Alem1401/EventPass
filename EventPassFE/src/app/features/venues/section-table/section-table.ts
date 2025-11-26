import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatIcon } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { responseSectionDto } from '../../../core/dtos/venue/response-section.dto';
import { SectionForm } from '../section-form/section-form';

@Component({
  selector: 'app-section-table',
  imports: [CommonModule, MatButton, MatIcon, SectionForm],
  templateUrl: './section-table.html',
  styleUrls: ['./section-table.css'],
})
export class SectionTable {
  showSectionTable = false;

  @Input() sections: responseSectionDto[] = [];
  @Output() removeSection = new EventEmitter<responseSectionDto>();
  isEditing: boolean = false;
  @Output() finishUpdating= new EventEmitter<{
    id: number;
    oldName: string;
    newName: string;
    oldCapacity: number;
    newCapacity: number;
  }>();

  selectedSection: responseSectionDto | null = null;

  toggleEditingStatus() {
    this.isEditing = !this.isEditing;
  }

  submitEditedSection(toUpdate: {
    id: number;
    oldName: string;
    newName: string;
    oldCapacity: number;
    newCapacity: number;
  }) {
    this.toggleEditingStatus();
    this.finishUpdating.emit(toUpdate);
  }

  startEditing(section: responseSectionDto): void {
    this.selectedSection = section;
    this.isEditing = true;
  }

  toggleSectionTable(): void {
    this.showSectionTable = !this.showSectionTable;
  }

  deleteSection(toDelete: responseSectionDto): void {
    this.removeSection.emit(toDelete);
  }
}
