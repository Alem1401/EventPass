export interface Event {
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

export interface EventCreate {
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

export interface EventUpdate {
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