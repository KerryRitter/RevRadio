import {IUser} from "../models/User";

export interface IUserService {
    login(email: string, username: string, password: string);
    register(email: string, username: string, password: string);
}

export class UserService implements IUserService {
    public login(email: string, username: string, password: string) {
        
    }
    
    public register(email: string, username: string, password: string) {
        
    }
}