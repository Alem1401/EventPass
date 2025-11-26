import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly baseUrl = `https://localhost:7231/api/EventCategories`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl);
  }

  getById(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.baseUrl}/${id}`);
  }

  create(dto: Category): Observable<Category> {
    return this.http.post<Category>(this.baseUrl, dto);
  }

  update(id: number, dto: Category): Observable<Category> {
    return this.http.put<Category>(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
