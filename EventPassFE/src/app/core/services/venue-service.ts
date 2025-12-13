import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { createUpdateVenueDto } from '../dtos/venue/create-update-venue.dto.';
import { venueTypeDto } from '../dtos/venue/venue-type.dto';
import { VenueResponseDto } from '../dtos/venue/venue-response.dto';
import { createSectionDto } from '../dtos/venue/create-section.dto';
import { responseSectionDto } from '../dtos/venue/response-section.dto';

@Injectable({
  providedIn: 'root',
})
export class VenueService {
  http = inject(HttpClient);

  addVenue(newVenue: createUpdateVenueDto) {
    return this.http.post('https://localhost:7231/api/Venue', newVenue);
  }

  getVenueTypes() {
    return this.http.get<venueTypeDto[]>(
      'https://localhost:7231/api/VenueTypes'
    );
  }

  getVenueById(id: number) {
    return this.http.get<VenueResponseDto>(
      `https://localhost:7231/api/Venue/${id}`
    );
  }

  updateVenue(venue: createUpdateVenueDto, id: number) {
    return this.http.put(`https://localhost:7231/api/Venue/${id}`, venue);
  }

  getAllVenues() {
    return this.http.get<VenueResponseDto[]>(
      'https://localhost:7231/api/Venue'
    );
  }

  addSectiontoVenue(section: createSectionDto) {
    return this.http.post('https://localhost:7231/api/Section', section);
  }

  getSectionsByVenue(venueId: number) {
    return this.http.get<responseSectionDto[]>(
      `https://localhost:7231/api/Section/venue/${venueId}`
    );
  }

  deleteVenue(venueId: number) {
    return this.http.delete(`https://localhost:7231/api/Venue/${venueId}`);
  }

  deleteSection(sectionId: number) {
    return this.http.delete(`https://localhost:7231/api/Section/${sectionId}`);
  }
  updateSection(section: { id: number; name: string; capacity: number }) {
    return this.http.put(`https://localhost:7231/api/Section/${section.id}`, {
      name: section.name,
      capacity: section.capacity,
    });
  }
}
