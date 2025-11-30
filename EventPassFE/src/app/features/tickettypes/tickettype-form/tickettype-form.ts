import { Component, Input, OnInit, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core'; 
import { responseSectionDto } from '../../../core/dtos/venue/response-section.dto';
import { VenueService } from '../../../core/services/venue-service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CreateUpdateTicketTypeDto } from '../../../core/dtos/tickettype/CreateUpdateTicketTypeDto';
import { TickettypeService } from '../../../core/services/tickettype-service';

@Component({
  selector: 'app-tickettype-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatOptionModule, 
  ],
  templateUrl: './tickettype-form.html',
  styleUrls: ['./tickettype-form.css'],
})
export class TickettypeForm implements OnInit {
  ticketTypeGroup = new FormGroup({
    price: new FormControl(0.0, {
      validators: [Validators.required, Validators.min(1)],
    }),
    remaining: new FormControl(0, {
      validators: [Validators.required, Validators.min(1)],
    }),
    section: new FormControl(0, {
      validators: [Validators.required, Validators.min(1)],
    }),
  });

  sections: responseSectionDto[] = [];
  route = inject(ActivatedRoute);
  router = inject(Router);
  service = inject(VenueService);
  ticketTypeService =inject(TickettypeService);
  venueId!: number;
  eventId!: number;
  ngOnInit(): void {
    const eid = this.route.snapshot.paramMap.get('eventid');
    const vid = this.route.snapshot.queryParamMap.get('venueid');
    if (eid && vid) {
      this.venueId = Number(vid);
      this.eventId = Number(eid);
      this.service.getSectionsByVenue(this.venueId).subscribe({
        next: (response) => {
          this.sections = response;
          console.log(response);
        },
      });
    }
  }

  addNew() {
    if (this.ticketTypeGroup.valid) {
      const nprice = this.ticketTypeGroup.controls.price.value;
      const nsectionId = this.ticketTypeGroup.controls.section.value;
      const nremaining = this.ticketTypeGroup.controls.remaining.value;
      const toAdd: CreateUpdateTicketTypeDto = {
        price: nprice || 0,
        sectionId: nsectionId || 1,
        ticketsRemaining: nremaining || 0,
        eventId: this.eventId,
      };
      this.ticketTypeService.addTicketType(toAdd).subscribe({
        next : () => this.router.navigate(["events/tickettypes/create/",this.eventId])
      })
    }
  }

 
  
}
