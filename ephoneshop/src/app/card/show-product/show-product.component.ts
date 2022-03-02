import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';

@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css']
})
export class ShowProductComponent implements OnInit {
  
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
