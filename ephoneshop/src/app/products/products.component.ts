import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { CheckoutComponent } from '../checkout/checkout.component';
import { EphoneAPIService } from './../ephone-api.service';
import { Pipe, PipeTransform } from '@angular/core';
import { FilterPipe } from '../shared/filter.pipe';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
//creating task export for checkboxes

export class ProductsComponent implements OnInit {
  public filterCategory : any;
  searchKey:string ="";

  constructor(private service:EphoneAPIService, private checkout : CheckoutComponent, private filterpipe : FilterPipe) { }

  
  typesOfProcessors: string[] = 
  [ 
    'Level 1 Processor', 
    'Level 2 Processor', 
    'Level 3 Processor', 
    'Level 4 Processor',
    'Ravi Processor'
];
  typesOfBrand: string[] = 
  [
    'Thamsung',
    'Doogle',
    'Universe',
    'PG',
    'Enginerola',
    'Dokia'
  ];
  typesOfSpeed: string[] = 
  [ 
    '5G', 
    '4G', 
    '3G',
];
  typesOfPrice: string[] = 
  [
    '$900+',
    '$800+',
    '4700+',
    '$600+',
    '$500+',
    '$400+',
    '#300-'
  ];
  ngOnInit(): void {
    this.api.service.getProduct()
    .subscribe(res=>{
      this.filterCategory = res;

      this.filterCategory.forEach((a:any)=>{
        if(a.category === "brands" || "speed"){
          a.category ="feature"
        }
        Object.assign(a,{quantity:1,total:a.price});
      });
      console.log(this.filterCategory);
    });


    this.filterCategory = res;
    this.checkout.search.subscribe((val:any)=>{
      this.searchKey = val;
    })
  }
  filter(category:string){
  this.filterCategory = this.typesOfProcessors
  .filter((a:any)=>{
    if(a.category == category || category==''){
      return a;
    }
  })
  }
}
