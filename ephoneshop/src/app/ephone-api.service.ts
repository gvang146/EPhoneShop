import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EphoneAPIService {
readonly APIUrl="http://localhost:60942/api";

  constructor(private http:HttpClient) { }

  getCusList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Customer');
  }

  addCustomer(val:any){
    return this.http.post(this.APIUrl+'/Customer',val);
  }

  updateCustomer(val:any){
    return this.http.put(this.APIUrl+'/Customer',val);
  }

  deleteCustomer(val:any){
    return this.http.delete(this.APIUrl+'/Customer/'+val);
  }

  getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }

  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Employee',val);
  }

  updateEmployee(val:any){
    return this.http.put(this.APIUrl+'/Employee',val);
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Employee/'+val);
  }

  getProList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Products');
  }

  addProducts(val:any){
    return this.http.post(this.APIUrl+'/Products',val);
  }

  updateProducts(val:any){
    return this.http.put(this.APIUrl+'/Products',val);
  }

  deleteProducts(val:any){
    return this.http.delete(this.APIUrl+'/Products/'+val);
  }


  getAllProducts():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Products/GetAllProducts');
  }
}