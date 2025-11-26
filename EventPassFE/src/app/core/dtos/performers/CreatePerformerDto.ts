import { CreateSocialMediaDto } from "./CreateSocialMediaDto";

export interface CreatePerformerDto {
  name: string;
  imageURL: string;
  website: string;
  socialMedia: CreateSocialMediaDto[];
}