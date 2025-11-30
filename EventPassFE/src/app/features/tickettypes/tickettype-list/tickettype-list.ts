import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ResponseTicketTypeDto } from '../../../core/dtos/tickettype/ResponseTicketTypeDto';
import { TickettypeService } from '../../../core/services/tickettype-service';
import { EventService } from '../../../core/services/event-service';
import { Event } from '../../../core/models/event.model';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-tickettype-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './tickettype-list.html',
  styleUrls: ['./tickettype-list.css'],
})
export class TickettypeListComponent implements OnInit {
  route = inject(ActivatedRoute);
  router = inject(Router)
  eventId!: number;
  ticketTypes: ResponseTicketTypeDto[] = [];
  ticketTypeService = inject(TickettypeService);
  eventService = inject(EventService);
  event : Event | null = null;
 
AddNewTicketType(){
  console.log("ovo je venueid prije slanja " + this.event?.venueId)
  this.router.navigate(
   ['/events/tickettypes/create', this.eventId],
    { queryParams: { venueid: this.event?.venueId } }

  );
}

 deleteTicketType(ticketTypeId : number){
  console.log(typeof(ticketTypeId));
   this.ticketTypeService.deleteTicketType(ticketTypeId).subscribe()
 }

  ngOnInit() {
    const id = this.route.snapshot.params['eventid'];
    if (id) {
      this.eventId = Number(id);
      this.ticketTypeService.getTicketTypesByEventId(this.eventId).subscribe({
        next: (response) => { this.ticketTypes = response; }
      });
      this.eventService.getEventById(this.eventId).subscribe({
        next: (response) => { this.event = response; console.log(this.event); }
      });
    }
  }
}