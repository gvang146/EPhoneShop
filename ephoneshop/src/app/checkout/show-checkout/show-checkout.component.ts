import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';
import { CartDetails } from 'src/app/_models/CartDetailsModel';

@Component({
  selector: 'app-show-checkout',
  templateUrl: './show-checkout.component.html',
  styleUrls: ['./show-checkout.component.css']
})
export class ShowCheckoutComponent implements OnInit {
  cartDetails: CartDetails[];
  constructor(private service:EphoneAPIService) { }

  ProductsList:any=[];

  ngOnInit(): void {
    this.refreshProList();
    this.GetCartDetails();
  }

  refreshProList(){
    this.service.GetAllProducts().subscribe(data=>{
      this.ProductsList=data;
    })
  }
  //getCartDetails
  GetCartDetails()
  {
    this.service.GetCartDetails().subscribe(data => {
      this.cartDetails = data;
    })
  }
}
