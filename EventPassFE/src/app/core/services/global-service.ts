import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GlobalService {
  private _headerActive = new BehaviorSubject<boolean>(false);
  headerActive$ = this._headerActive.asObservable();

  headerVisible(value: boolean) {
    this._headerActive.next(value);
  }
}
