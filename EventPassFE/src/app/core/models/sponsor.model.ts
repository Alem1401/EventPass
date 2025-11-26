export interface Sponsor
{
    id: number,
    name: string,
    logoUrl: string,
    websiteUrl: string,
    email: string,
    phone: string
}

export interface SponsorCreate
{
    name: string,
    logoUrl: string,
    websiteUrl: string,
    email: string,
    phone: string
}