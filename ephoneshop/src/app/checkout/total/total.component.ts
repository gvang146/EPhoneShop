import { Component, OnInit } from '@angular/core';
import { CartDetails } from 'src/app/_models/CartDetailsModel';
import { EphoneAPIService } from 'src/app/ephone-api.service';

@Component({
  selector: 'app-total',
  templateUrl: './total.component.html',
  styleUrls: ['./total.component.css']
})
export class TotalComponent implements OnInit {
  cartDetails: CartDetails[];
  constructor(private service:EphoneAPIService) { }

  totalCost=0;

  ngOnInit(): void {
  this.GetCartDetails;
  }

  GetTotalCost(data:any[]){
    for(var index in data){
      this.totalCost += data[index].price;
    }
  }

  GetCartDetails()
  {
    this.service.GetCartDetails().subscribe(data => {
      this.cartDetails = data;
      this.GetTotalCost(data);
    })
  }
}
