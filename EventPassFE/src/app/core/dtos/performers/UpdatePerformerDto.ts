import { UpdateSocialMediaDto } from "./UpdateSocialMediaDto";

export interface UpdatePerformerDto {
  name: string;
  imageURL: string;
  website: string;
  socialMedia: UpdateSocialMediaDto[];
}
