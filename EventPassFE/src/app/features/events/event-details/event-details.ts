import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatTableModule } from '@angular/material/table';
import { MatBadgeModule } from '@angular/material/badge';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ResponseEventDto } from '../../../core/models/event.model';
import { EventService } from '../../../core/services/event-service';
import { ResponseTicketTypeDto } from '../../../core/dtos/tickettype/ResponseTicketTypeDto';
import { VenueService } from '../../../core/services/venue-service';
import { TickettypeService } from '../../../core/services/tickettype-service';
import { VenueResponseDto } from '../../../core/dtos/venue/venue-response.dto';
import { SponsorService } from '../../../core/services/sponsor-service';
import { TicketService } from '../../../core/services/ticket-service';

@Component({
  selector: 'app-event-details',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatDividerModule,
    MatTableModule,
    MatBadgeModule,
    MatTooltipModule,
    MatSelectModule,
    MatFormFieldModule,
  ],
  templateUrl: './event-details.html',
  styleUrls: ['./event-details.css'],
})
export class EventDetailsComponent implements OnInit {
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.eventId = Number(id);
      this.loadEventData(this.eventId);
    }
  }

  eventId: number | null = null;
  venueService = inject(VenueService);
  ticketService = inject(TickettypeService);
  eventService = inject(EventService);
  sponsorService = inject(SponsorService);
  tService = inject(TicketService);
  eventVenue: VenueResponseDto | null = null;
  currentEvent: ResponseEventDto | null = null;
  ticketTypes: ResponseTicketTypeDto[] = [];
  // per-ticket quantity selections (ticketId -> quantity)
  quantityMap: Record<number, number> = {};

  displayedColumns: string[] = [
    'type',
    'price',
    'available',
    'quantity',
    'action',
  ];

  route = inject(ActivatedRoute);

  loadEventData(id: number) {
    this.eventService.getEventById(id).subscribe({
      next: (response) => {
        this.currentEvent = response;
        this.loadVenueData(this.currentEvent.venueId);
        // TODO: sponsor service needs to implement getSponsorsByEventId
      },
      error: (err) => {
        console.error('Error loading event details', err);
      },
    });
    this.ticketService.getTicketTypesByEventId(id).subscribe({
      next: (response) => (this.ticketTypes = response),
    });
  }

  loadVenueData(id: number) {
    this.venueService.getVenueById(id).subscribe({
      next: (response) => (this.eventVenue = response),
    });
  }
  selectTicket(ticketType: string): void {
    console.log('Selected ticket:', ticketType);
  }

  getQuantity(ticketId: number): number {
    return this.quantityMap[ticketId] || 0;
  }

  increment(ticketId: number, max: number): void {
    const current = this.getQuantity(ticketId);
    if (current < max) {
      this.quantityMap[ticketId] = current + 1;
    }
  }

  decrement(ticketId: number): void {
    const current = this.getQuantity(ticketId);
    if (current > 0) {
      this.quantityMap[ticketId] = current - 1;
    }
  }

  downloadPdf(id: number) {
    this.tService.getTicketPdf(1).subscribe((respone: Blob) => {
      const blob: Blob = new Blob([respone], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
    });
  }

  orderTickets(filter: any) {
    const eID: number = this.eventId ? this.eventId : 0;
    this.ticketService.orderTicketType(eID, filter.value).subscribe({
      next : (response) =>  this.ticketTypes = response,
    });
  }

  addToCart(ticketId: number): void {
    const qty = this.getQuantity(ticketId);
    if (qty <= 0) {
      console.warn('No quantity selected for ticket', ticketId);
      return;
    }
    console.log('Adding to cart:', { ticketId, qty });
    // TODO: integrate with cart service
  }
}
