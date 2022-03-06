import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';

@Component({
  selector: 'app-show-checkout',
  templateUrl: './show-checkout.component.html',
  styleUrls: ['./show-checkout.component.css']
})
export class ShowCheckoutComponent implements OnInit {

  constructor(private service:EphoneAPIService) { }

  ProductsList:any=[];

  ngOnInit(): void {
    this.refreshProList();
  }

  refreshProList(){
    this.service.GetAllProducts().subscribe(data=>{
      this.ProductsList=data;
    })
  }
}
