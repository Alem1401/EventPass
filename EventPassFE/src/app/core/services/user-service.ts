import { inject, Injectable } from '@angular/core';
import { registerUserDto } from '../dtos/auth/register-user.dto';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { loginUserDto } from '../dtos/auth/login-user.dto';
import { authResponseDto } from '../dtos/auth/authresponse.dto';
import { currentUserDto } from '../dtos/auth/currentuser.dto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private httpclient = inject(HttpClient);
  private token: string = '';
  private currentUser = new BehaviorSubject<currentUserDto | null>(null);
  currentUser$ = this.currentUser.asObservable();

  setAuthProperties(response: authResponseDto) {
    this.token = response.token;
    localStorage.setItem('jwt_token', this.token);
    this.currentUser.next({
      name: response.name,
      surname: response.surname,
      email: response.email,
    });
  }

  registerUser(user: registerUserDto): Observable<any> {
    return this.httpclient.post(
      'https://localhost:7231/api/Users/register',
      user
    );
  }

  loginUser(user: loginUserDto) {
    return this.httpclient.post<authResponseDto>(
      'https://localhost:7231/api/Users/login',
      user
    );
  }
}
