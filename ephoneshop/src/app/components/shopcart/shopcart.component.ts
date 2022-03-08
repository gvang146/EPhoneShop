import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';
import { CartDetails } from 'src/app/_models/CartDetailsModel';

@Component({
  selector: 'app-shopcart',
  templateUrl: './shopcart.component.html',
  styleUrls: ['./shopcart.component.css']
})
export class ShopcartComponent implements OnInit {
  cartDetails: CartDetails[];
  displayedColumns: string[] = ['productName','price','quantity'];
  constructor(private service: EphoneAPIService) { }

  ngOnInit(): void {
    this.GetCartDetails();
  }

  //getCartDetails
  GetCartDetails()
  {
    this.service.GetCartDetails().subscribe(data => {
      this.cartDetails = data;
    })
  }

}
