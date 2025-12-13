import { HttpClient } from '@angular/common/http';
import { Injectable,inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  
  http = inject(HttpClient);

  getTicketPdf(id: number){
   return this.http.get(`https://localhost:7231/api/Tickets/pdf/${id}`,{responseType: 'blob'})
  }
}
