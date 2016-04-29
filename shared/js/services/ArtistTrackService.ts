import {IArtistTrack} from "../models/ArtistTrack";

export interface IArtistTrackService {
    getAll();
    get(id: number);
    create(artist: IArtistTrack);
    update(id: number, artist: IArtistTrack);
    delete(id: number);
}

export class ArtistTrackService implements IArtistTrackService {
    public getAll() {
        
    }
    
    public get(id: number) {
        
    }
    
    public create(artist: IArtistTrack) {
        
    }
    
    public update(id: number, artist: IArtistTrack) {
        
    }
    
    public delete(id: number) {
        
    }
}