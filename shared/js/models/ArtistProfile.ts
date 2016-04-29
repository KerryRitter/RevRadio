import {IUser} from "./User";

export interface IArtistProfile {
    owners: IUser[];
    
    name: string;
    hometown_city: string;
    hometown_state: string;
    biography: string;
    
    website_url: string;
    facebook_url: string;
    twitter_url: string;
    bandcamp_url: string;

    created_at: Date;
}