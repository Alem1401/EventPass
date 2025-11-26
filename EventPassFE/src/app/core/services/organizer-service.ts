import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Organizer } from '../models/organizer.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService {
  private readonly baseUrl = `https://localhost:7231/api/Organizers`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Organizer[]> {
    return this.http.get<Organizer[]>(this.baseUrl);
  }

  getById(id: number): Observable<Organizer> {
    return this.http.get<Organizer>(`${this.baseUrl}/${id}`);
  }

  create(dto: Organizer): Observable<Organizer> {
    return this.http.post<Organizer>(this.baseUrl, dto);
  }

  update(id: number, dto: Organizer): Observable<Organizer> {
    return this.http.put<Organizer>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
