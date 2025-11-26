import { Routes } from '@angular/router';
import { RegisterComponent } from './features/auth/register/register';
import { LoginComponent } from './features/auth/login/login';
import { EventFormComponent } from './features/events/event-form/event-form';
import { EventListComponent } from './features/events/event-list/event-list';
import { SponsorFormComponent } from './features/sponsors/sponsor-form/sponsor-form';
import { SponsorsListComponent } from './features/sponsors/sponsor-list/sponsor-list';
import { PerformerFormComponent } from './features/performers/performer-form/performer-form';
import { PerformerListComponent } from './features/performers/performer-list/performer-list';
import { VenueForm } from './features/venues/venue-form/venue-form';

export const routes: Routes = [
    {path:"auth/register",component: RegisterComponent},
    {path:"auth/login",component: LoginComponent},
    { path: 'events', component: EventListComponent},
    { path: 'events/create', component: EventFormComponent},
    { path: 'events/edit/:id', component: EventFormComponent},
    { path: 'sponsors/create', component: SponsorFormComponent},
    { path: 'sponsors/edit/:id', component: SponsorFormComponent},
    { path: 'sponsors', component: SponsorsListComponent},
    { path: "performers", component: PerformerListComponent },
    { path: "performers/create", component: PerformerFormComponent },
    { path: "performers/edit/:id", component: PerformerFormComponent },
    {path : "venues/create", component: VenueForm},
    {path : "venues/edit/:id", component: VenueForm},
    { path: '', redirectTo: '/auth/register', pathMatch: 'full' }
];
