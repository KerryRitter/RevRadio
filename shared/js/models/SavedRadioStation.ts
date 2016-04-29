import {IUser} from "./User";

export interface ISavedRadioStation {
    owner: IUser,
    search_query: string;
    created_at: Date;
}