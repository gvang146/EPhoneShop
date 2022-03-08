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
 
  GetProductByBrand(brand:string[]):Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product/brand/' + brand)
  }

  GetProductByProcessor(processor:string[]):Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product/processor/' + processor)
  }

  GetProductBySpeed(speed:string[]):Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product/speed/' + speed)
  }
}
