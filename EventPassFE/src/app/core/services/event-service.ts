import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseEventDto, CreateEventDto, UpdateEventDto } from '../models/event.model';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private apiUrl = 'https://localhost:7231/api/Events';

  constructor(private http: HttpClient) { }

  getAllEvents(): Observable<ResponseEventDto[]> {
    return this.http.get<ResponseEventDto[]>(this.apiUrl);
  }

  getEventById(id: number): Observable<ResponseEventDto> {
    return this.http.get<ResponseEventDto>(`${this.apiUrl}/${id}`);
  }

  searchEventsByName(name: string): Observable<ResponseEventDto[]> {
    const params = new HttpParams().set('name', name);
    return this.http.get<ResponseEventDto[]>(`${this.apiUrl}/search`, { params });
  }

  createEvent(event: CreateEventDto): Observable<ResponseEventDto> {
    return this.http.post<ResponseEventDto>(this.apiUrl, event);
  }

  updateEvent(id: number, event: UpdateEventDto): Observable<ResponseEventDto> {
    return this.http.put<ResponseEventDto>(`${this.apiUrl}/${id}`, event);
  }

  deleteEvent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}