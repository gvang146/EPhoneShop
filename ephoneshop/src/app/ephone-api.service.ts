import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EphoneAPIService {
  readonly APIUrl = "https://localhost:7225/";
  priceNum: string;

  constructor(private service :HttpClient) { }

  GetAllProducts():Observable<any[]>
  {
    return this.service.get<any>(this.APIUrl + 'Product');
  }

 /*
 retrieve data from database
 1. click a filter
 2. make the query specific for the filter
 3. send it to the ephone api
 4. the api queries the database with filter
 5. it sends back the data to the webpage
 6. when filter is unclicked run get all products
 */

  GetMin() {
    return this.service.get<any>(this.APIUrl + 'GetProductByPriceMin');
  }

  GetPriceSpecific(price: string) {
    if (price == 'Low-High') {
      this.GetMin();
    }
    else if (price == 'High-Low') {
      //this.GetMax();
    }
    else
      this.priceNum = price.replace('+', '');


    return this.service.get<any>(this.APIUrl + 'GetProductByPriceSpecfic');
  }
}
