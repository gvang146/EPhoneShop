import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models/UserLoginModel';

@Injectable({ providedIn: 'root' })
export class UserService {
    readonly APIUrl="https://localhost:7225/";
    constructor(private service: HttpClient) { }

    getAll() {
        return this.service.get<User[]>(this.APIUrl + 'User');
    }
}