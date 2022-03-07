import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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
  GetCartItems(userId: any)
  {
    return this.service.get<any>(this.APIUrl + 'Cart/' + userId)
  }
  //Add To cart method
  AddToCart(productId: any)
  {
    return this.service.post<any>(this.APIUrl + 'Carts', productId);
  }
}
