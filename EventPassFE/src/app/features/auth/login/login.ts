import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { Router, RouterModule } from '@angular/router';
import { loginUserDto } from '../../../core/dtos/auth/login-user.dto';
import { UserService } from '../../../core/services/user-service';
import {
  ReactiveFormsModule,
  FormsModule,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class LoginComponent {
  hidePassword: boolean = true;
  userService = inject(UserService);
router = inject(Router);
  loginForm = new FormGroup({
    email: new FormControl('', { validators: Validators.required }),
    password: new FormControl('', { validators: Validators.required }),
  });
  Login() {
    const loginRequest: loginUserDto = {
      email: this.loginForm.controls.email.value || ' ',
      password: this.loginForm.controls.password.value || ' ',
    };
    this.userService.loginUser(loginRequest).subscribe({
      next: (response) => {this.userService.setAuthProperties(response)
        this.router.navigate([""]);

      },
      error: (er) => console.log(er),
    });
  }
}
