import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sponsor, SponsorCreate } from '../models/sponsor.model';

@Injectable({
  providedIn: 'root'
})
export class SponsorService {
  private apiUrl = 'https://localhost:7231/api/Sponsors';

  constructor(private http: HttpClient) { }

  getAllSponsors(): Observable<Sponsor[]> {
    return this.http.get<Sponsor[]>(this.apiUrl);
  }

  getSponsorById(id: number): Observable<Sponsor> {
    return this.http.get<Sponsor>(`${this.apiUrl}/${id}`);
  }

  searchSponsorsByName(name : string): Observable<Sponsor[]>{
    const params = new HttpParams().set('name', name);
    return this.http.get<Sponsor[]>(`${this.apiUrl}/search`, { params })
  }

  createSponsor(event: SponsorCreate): Observable<Sponsor> {
    return this.http.post<Sponsor>(this.apiUrl, event);
  }

  updateSponsor(id: number, event: SponsorCreate): Observable<Sponsor> {
    return this.http.put<Sponsor>(`${this.apiUrl}/${id}`, event);
  }

  deleteSponsor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}