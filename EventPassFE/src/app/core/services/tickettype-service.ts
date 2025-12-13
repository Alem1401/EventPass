import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ResponseTicketTypeDto } from '../dtos/tickettype/ResponseTicketTypeDto';
import { CreateUpdateTicketTypeDto } from '../dtos/tickettype/CreateUpdateTicketTypeDto';

@Injectable({
  providedIn: 'root',
})
export class TickettypeService {
  http = inject(HttpClient);

  getTicketTypesByEventId(eventId: number) {
    return this.http.get<ResponseTicketTypeDto[]>(
      `https://localhost:7231/api/TicketTypes/ByEvent/${eventId}`
    );
  }

  addTicketType(newTicket: CreateUpdateTicketTypeDto) {
    return this.http.post(
      `https://localhost:7231/api/TicketTypes
`,
      newTicket
    );
  }

  deleteTicketType(ticketTypeId : number){
    return this.http.delete(`https://localhost:7231/api/TicketTypes/${ticketTypeId}`)
  }

  orderTicketType(eventId: number,orderBy : string){
    return this.http.get<ResponseTicketTypeDto[]>(`https://localhost:7231/api/TicketTypes/ByEvent/${eventId}/order?orderBy=${orderBy}`)
  }
}
