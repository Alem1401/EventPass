import { HttpClient } from '@angular/common/http';
import { Injectable,inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  
 http = inject(HttpClient);

 getSearchSuggestiosn(searchTerm : string) : Observable<string[]>{
  return this.http.get<string[]>(`https://localhost:7231/api/Search/suggestions?term=${searchTerm}`)
 }

}
