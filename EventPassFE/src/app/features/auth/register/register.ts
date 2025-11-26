import { Component, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { registerUserDto } from '../../../core/dtos/auth/register-user.dto';
import { UserService } from '../../../core/services/user-service';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { isPropertyAssignment } from 'typescript';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.html',
  styleUrls: ['./register.css'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    RouterModule
  ],
})
export class RegisterComponent {
  userService = inject(UserService);
  router = inject(Router);
  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
    ]),
    confirmPassword: new FormControl('', Validators.required),
  });

  passwordValid: boolean = true;
  isStrongPassword(password: string): boolean {
    const hasUpperCase = /[A-Z]/;
    const hasSpecialChar = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
    return hasUpperCase.test(password) && hasSpecialChar.test(password);
  }

  registerUser() {
    const user: registerUserDto = {
      Name: this.registerForm.controls.firstName.value || '',
      Surname: this.registerForm.controls.lastName.value || '',
      Email: this.registerForm.controls.email.value || '',
      Password: this.registerForm.controls.password.value || '',
    };

    this.passwordValid = this.isStrongPassword(user.Password);

    if (!this.passwordValid) {
      return;
    }
    console.log('Sending user data:', user);

    this.userService.registerUser(user).subscribe({
      next: (response) => {
        console.log('Success:', response);
        this.router.navigate(['']);
      },
      error: (err) => {
        console.error('Full error object:', err);
        console.error('Backend response:', err.error);

        if (err.error) {
          if (err.error.Errors) {
            console.error('Validation errors:', err.error.Errors);
          } else if (err.error.Message) {
            console.error('Error message:', err.error.Message);
          } else if (typeof err.error === 'string') {
            console.error('Error string:', err.error);
          }
        }
      },
    });
    }
    
  }
