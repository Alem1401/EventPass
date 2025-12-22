import { Component, OnInit,inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { EventCardComponent } from '../event-card/event-card';
import { PluralizePipe } from '../../../core/pipes/pluralize.pipe';
import { EventService } from '../../../core/services/event-service';
import { SearchService } from '../../../core/services/search-service';
import { ResponseEventDto } from '../../../core/models/event.model';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    EventCardComponent,
    PluralizePipe
  ],
  templateUrl: './landing-page.html',
  styleUrls: ['./landing-page.css']
})
export class LandingPageComponent implements OnInit {
  searchQuery: string = '';
  selectedCategory: string = 'all';
  loading: boolean = false;
  
  
  suggestions: string[] = [];
  showSuggestions: boolean = false;
  
  events_ : ResponseEventDto[] = [];


  filteredEvents = [...this.events_];

  eventService = inject(EventService)
  searchService = inject(SearchService)
  ngOnInit(): void {
   this.eventService.getAllEvents().subscribe({
    next: (response) => {this.events_ = response
      console.log(response)
    }
   })
  }

  onSearch(): void {
    this.showSuggestions = false;
    this.filterEvents();
  }

  onSearchInput(): void {
    if (this.searchQuery.trim().length > 0) {
      this.searchService.getSearchSuggestiosn(this.searchQuery).subscribe({
        next: (results) => {
          this.suggestions = results;
          this.showSuggestions = true;
        }
      });
    } else {
      this.suggestions = [];
      this.showSuggestions = false;
    }
  }

  onSearchFocus(): void {
    if (this.suggestions.length > 0) {
      this.showSuggestions = true;
    }
  }

  onSearchBlur(): void {
    this.showSuggestions = false;
  }

  selectSuggestion(suggestion: string): void {
    this.searchQuery = suggestion;
    this.showSuggestions = false;
   
  }

  clearSearch(): void {
    this.searchQuery = '';
    this.suggestions = [];
    this.showSuggestions = false;
  }

  filterByCategory(category: string): void {
    this.selectedCategory = category;
    this.filterEvents();
  }

  filterEvents(): void {
    let results = [...this.events_];

    if (this.selectedCategory !== 'all') {
      results = results.filter(event => event.categoryName === this.selectedCategory);
    }

  
    if (this.searchQuery.trim()) {
      const query = this.searchQuery.toLowerCase();
      results = results.filter(event => 
        event.name.toLowerCase().includes(query) ||
        event.description.toLowerCase().includes(query)
      );
    }

    this.filteredEvents = results;
  }

  clearFilters(): void {
    this.searchQuery = '';
    this.selectedCategory = 'all';
    this.filteredEvents = [...this.events_];
  }
}
