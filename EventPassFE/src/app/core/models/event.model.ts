export interface ResponseEventDto {
  id: number;
  name: string;
  description: string;
  bannerURL: string;
  startDate: string;  
  endDate: string;    
  duration: string;
  minimumAge: number;
  performerID: number;
  performerName: string;
  categoryId: number;
  categoryName: string;
  organizerID: number;
  organizerName: string;
  venueId: number;
  venueName: string;
}

export interface CreateEventDto {
  name: string;
  description: string;
  bannerURL: string;
  startDate: string;  
  endDate: string;    
  duration: string;
  minimumAge: number;
  performerID: number;
  categoryId: number;
  organizerID: number;
  venueID: number;
}

export interface UpdateEventDto {
  name: string;
  description: string;
  bannerURL: string;
  startDate: string;  
  endDate: string;    
  duration: string;
  minimumAge: number;
  performerID: number;
  categoryId: number;
  organizerID: number;
  venueID: number;
}