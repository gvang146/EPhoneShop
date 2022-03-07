import { Injectable } from '@angular/core';  
import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { UserSignUpModel } from '../_models/UserSignupModel';

@Injectable({
    providedIn: 'root'
})
export class SignupService {
    readonly APIUrl="https://localhost:7225/";
    token: string = '';
    header: any;
    constructor(private service: HttpClient) {
        const headerSettings: {[name: string]: string[];} = {}
        this.header = new HttpHeaders(headerSettings);
    }
    CreateUser(user: UserSignUpModel)
    {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        return this.service.post<UserSignUpModel>(this.APIUrl + 'User/create', user, httpOptions);
    }

}