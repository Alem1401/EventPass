import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Performer } from '../models/performer.model';
import { UpdatePerformerDto } from '../dtos/performers/UpdatePerformerDto';
import { CreatePerformerDto } from '../dtos/performers/CreatePerformerDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerformerService {
  private readonly baseUrl = 'https://localhost:7231/api/performers';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Performer[]> {
    return this.http.get<Performer[]>(this.baseUrl);
  }

  getById(id: number): Observable<Performer> {
    return this.http.get<Performer>(`${this.baseUrl}/${id}`);
  }

  create(dto: CreatePerformerDto): Observable<Performer> {
    return this.http.post<Performer>(this.baseUrl, dto);
  }

  update(id: number, dto: UpdatePerformerDto): Observable<Performer> {
    return this.http.put<Performer>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
