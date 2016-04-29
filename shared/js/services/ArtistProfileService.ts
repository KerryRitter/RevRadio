import {IArtistProfile} from "../models/ArtistProfile";

export interface IArtistProfileService {
    getAll();
    get(id: number);
    create(artist: IArtistProfile);
    update(id: number, artist: IArtistProfile);
    delete(id: number);
}

export class ArtistProfileService implements IArtistProfileService {
    public getAll() {
        
    }
    
    public get(id: number) {
        
    }
    
    public create(artist: IArtistProfile) {
        
    }
    
    public update(id: number, artist: IArtistProfile) {
        
    }
    
    public delete(id: number) {
        
    }
}