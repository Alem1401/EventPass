import { ResponseSocialMediaDto } from "../dtos/performers/ResponseSocialMediaDto";

export interface Performer {
  id: number;
  name: string;
  imageURL: string;
  website: string;
  socialMedia: ResponseSocialMediaDto[];
}

