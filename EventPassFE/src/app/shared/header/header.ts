import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { UserService } from '../../core/services/user-service';
import { Subscription } from 'rxjs';
import { currentUserDto } from '../../core/dtos/auth/currentuser.dto';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, MatToolbarModule, MatButtonModule, MatIconModule, RouterLink],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class HeaderComponent implements OnInit, OnDestroy {
   
  service = inject(UserService);
  currentUser: currentUserDto | null = null;
  private userSubscription: Subscription | undefined;

  ngOnInit(): void {
 
   this.userSubscription = this.service.currentUser$.subscribe(user => {
      this.currentUser = user;
      
    });
  }

  ngOnDestroy(): void {
    this.userSubscription?.unsubscribe();
  }
}