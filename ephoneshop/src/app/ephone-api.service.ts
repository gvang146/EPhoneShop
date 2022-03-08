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

  GetAllProducts():Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product');
  }
  GetCartItems(userId: any)
  {
    return this.service.get<any>(this.APIUrl + 'Cart/' + userId)
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
}
