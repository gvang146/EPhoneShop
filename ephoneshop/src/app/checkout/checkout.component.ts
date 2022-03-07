import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  constructor(private service:EphoneAPIService) { }

  ProductsList:any=[];
  ProductSum:any=[];
  ProductCount:any=[];


  ngOnInit(): void {
    this.refreshProList();
  }


  refreshProList(){
    this.service.GetAllProducts().subscribe(data=>{
      this.ProductsList=data;
    })
  }
  onSubmit()
  {
    
  }
}
