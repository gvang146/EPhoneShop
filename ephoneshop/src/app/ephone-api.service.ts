import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EphoneAPIService {
readonly APIUrl="https://localhost:7225/";

  constructor(private service :HttpClient) { }

  GetAllProducts():Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product');
  }
 
}
