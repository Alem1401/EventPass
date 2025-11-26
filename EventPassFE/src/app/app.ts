import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./shared/header/header";
import { RegisterComponent } from "./features/auth/register/register";
import { FooterComponent } from "./shared/footer/footer";
import { LoginComponent } from './features/auth/login/login';
import { EventFormComponent } from './features/events/event-form/event-form';
import { EventListComponent } from './features/events/event-list/event-list';
import { SponsorFormComponent } from './features/sponsors/sponsor-form/sponsor-form';
import { VenueForm } from "./features/venues/venue-form/venue-form";

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    HeaderComponent,
    RegisterComponent,
    FooterComponent,
    LoginComponent,
    EventFormComponent,
    EventListComponent,
    SponsorFormComponent,
    VenueForm
],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'EventPassFE';
}
