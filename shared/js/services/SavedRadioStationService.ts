import {ISavedRadioStation} from "../models/SavedRadioStation";

export interface ISavedRadioStationService {
    getAll();
    get(id: number);
    create(savedRadioStation: ISavedRadioStation);
    update(id: number, savedRadioStation: ISavedRadioStation);
    delete(id: number);
}

export class SavedRadioStationService implements ISavedRadioStationService {
    public getAll() {
        
    }
    
    public get(id: number) {
        
    }
    
    public create(savedRadioStation: ISavedRadioStation) {
        
    }
    
    public update(id: number, savedRadioStation: ISavedRadioStation) {
        
    }
    
    public delete(id: number) {
        
    }
}