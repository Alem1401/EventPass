import { Routes } from '@angular/router';

export const routes: Routes = [
    // Landing page as default route
    {
        path: '',
        loadComponent: () => import('./features/landingpage/landing-page/landing-page').then(m => m.LandingPageComponent),
        pathMatch: 'full'
    },

    // Public event details page
    {
        path: 'events/details/:id',
        loadComponent: () => import('./features/events/event-details/event-details').then(m => m.EventDetailsComponent)
    },

    // Auth routes
    { 
        path: "auth/register", 
        loadComponent: () => import('./features/auth/register/register').then(m => m.RegisterComponent)
    },
    { 
        path: "auth/login", 
        loadComponent: () => import('./features/auth/login/login').then(m => m.LoginComponent)
    },

    // Admin panel with nested routes
    {
        path: 'admin',
        loadComponent: () => import('./features/admin/admin-panel/admin-panel').then(m => m.AdminPanelComponent),
        children: [
            {
                path: 'events',
                children: [
                    { 
                        path: '', 
                        loadComponent: () => import('./features/events/event-list/event-list').then(m => m.EventListComponent)
                    },
                    { 
                        path: 'create', 
                        loadComponent: () => import('./features/events/event-form/event-form').then(m => m.EventFormComponent)
                    },
                    { 
                        path: 'edit/:id', 
                        loadComponent: () => import('./features/events/event-form/event-form').then(m => m.EventFormComponent)
                    },
                    {
                        path: 'tickettypes',
                        children: [
                            { 
                                path: 'list/:eventid', 
                                loadComponent: () => import('./features/tickettypes/tickettype-list/tickettype-list').then(m => m.TickettypeListComponent)
                            },
                            { 
                                path: 'create/:eventid', 
                                loadComponent: () => import('./features/tickettypes/tickettype-form/tickettype-form').then(m => m.TickettypeForm)
                            }
                        ]
                    }
                ]
            },
            {
                path: 'sponsors',
                children: [
                    { 
                        path: '', 
                        loadComponent: () => import('./features/sponsors/sponsor-list/sponsor-list').then(m => m.SponsorsListComponent)
                    },
                    { 
                        path: 'create', 
                        loadComponent: () => import('./features/sponsors/sponsor-form/sponsor-form').then(m => m.SponsorFormComponent)
                    },
                    { 
                        path: 'edit/:id', 
                        loadComponent: () => import('./features/sponsors/sponsor-form/sponsor-form').then(m => m.SponsorFormComponent)
                    }
                ]
            },
            {
                path: 'performers',
                children: [
                    { 
                        path: '', 
                        loadComponent: () => import('./features/performers/performer-list/performer-list').then(m => m.PerformerListComponent)
                    },
                    { 
                        path: 'create', 
                        loadComponent: () => import('./features/performers/performer-form/performer-form').then(m => m.PerformerFormComponent)
                    },
                    { 
                        path: 'edit/:id', 
                        loadComponent: () => import('./features/performers/performer-form/performer-form').then(m => m.PerformerFormComponent)
                    }
                ]
            },
            {
                path: 'venues',
                children: [
                    { 
                        path: '', 
                        loadComponent: () => import('./features/venues/venue-list/venue-list').then(m => m.VenueListComponent)
                    },
                    { 
                        path: 'create', 
                        loadComponent: () => import('./features/venues/venue-form/venue-form').then(m => m.VenueForm)
                    },
                    { 
                        path: 'edit/:id', 
                        loadComponent: () => import('./features/venues/venue-form/venue-form').then(m => m.VenueForm)
                    }
                ]
            },
            {
                path: 'users',
                children: [
                    { 
                        path: '', 
                        loadComponent: () => import('./features/users/user-list/user-list').then(m => m.UserListComponent)
                    }
                ]
            },
            
            { path: '', redirectTo: 'events', pathMatch: 'full' }
        ]
    }
];
