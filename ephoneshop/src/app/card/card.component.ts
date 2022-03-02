import { Component, OnInit } from '@angular/core';
import { ProductsComponent } from '../products/products.component';
import { EphoneAPIService } from '../ephone-api.service';


@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  constructor(private service:EphoneAPIService) { }

  ProductsList:any=[];

  ngOnInit(): void {
    this.refreshProList();
  }

  refreshProList(){
    this.service.getProList().subscribe(data=>{
      this.ProductsList=data;
    })
  }

}
