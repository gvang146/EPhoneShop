import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'http://localhost:60942/api';
const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private server: HttpClient) { }

  login(credentials): Observable<any> {
    return this.server.post(AUTH_API + 'signin', {
      username: credentials.username,
      password: credentials.password
    }, httpOptions);
  }
  register(user) : Observable<any> {
    return this.server.post(AUTH_API + 'signup', {
      email: user.email,
      password: user.password
    }, httpOptions)
  }
}
