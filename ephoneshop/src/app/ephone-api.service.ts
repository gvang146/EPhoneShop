import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from './_models/CartModel';

@Injectable({
  providedIn: 'root'
})
export class EphoneAPIService {
readonly APIUrl="https://localhost:7225/";

  constructor(private service :HttpClient) { }

  //GetAllProducts
  GetAllProducts():Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product');
  }

  //Get CartDetails
  GetCartDetails():Observable<any[]>
  {
    let token = localStorage.getItem('token') ?? '';
    let headers = new HttpHeaders({
      'Content-Type' : 'application/json; charset=UTF-8',
      'Authorization': `Bearer ${token}`
    });
    return this.service.get<any>(this.APIUrl + 'Carts', {headers: headers}); //defined that this line will have these headers
  }

  //
  GetCartItems(userId: any)
  {
    return this.service.get<any>(this.APIUrl + 'Carts/' + userId)
  }
  
  //Add To cart method
  AddItemToCart(cart: Cart)
  {
    let token = localStorage.getItem('token') ?? '';
    let headers = new HttpHeaders({
      'Content-Type' : 'application/json; charset=UTF-8',
      'Authorization': `Bearer ${token}`
    });
    return this.service.post<any>(this.APIUrl + 'Carts', cart, { headers : headers });
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

  //deleteAllCartItems
  DeleteAllCartItems()
  {
    return this.service.delete(this.APIUrl + 'Carts');
  }
}
