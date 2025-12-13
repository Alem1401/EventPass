import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { TruncatePipe } from '../../../core/pipes/truncate.pipe';
import { ResponseEventDto } from '../../../core/models/event.model';

@Component({
  selector: 'app-event-card',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    TruncatePipe
  ],
  templateUrl: './event-card.html',
  styleUrls: ['./event-card.css']
})
export class EventCardComponent {
  @Input() event?: ResponseEventDto;
}
