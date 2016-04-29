import {IArtistProfile} from "./ArtistProfile";
import {IUser} from "./User";

export interface IArtistTrack {
    artist: IArtistProfile;
    created_by: IUser;
    
    title: string;
    release_title: string;
    release_date: string;
    audio_file_url: string;
    image_file_url: string;
    created_at: Date;
}