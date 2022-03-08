import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { EphoneAPIService } from '../ephone-api.service';



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
//creating task export for checkboxes

export class ProductsComponent implements OnInit {
  ProductsList:any=[];
  filteredProducts: string[];
  selectedOption: string;
  private _filterWord : string;
  //Getter for the word
  get filterWord(): string {
    return this._filterWord;
  }
  //setter for the work and callnig the method
  set filterWord(value: string)
  {
    this._filterWord = value;
    //this.filteredProducts = this.filteredProducts(value);
  }
  constructor(private service: EphoneAPIService) { }
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
      'Low-High',
      'High-Low',
    '$900+',
    '$800+',
    '4700+',
    '$600+',
    '$500+',
    '$400+',
    '#300-'
  ];
  ngOnInit(): void {
    this.refreshProList();

  }

  //create flter employee method
  filterProducts(filterword: string)
  {

  }
  refreshProList(){
    this.service.GetAllProducts().subscribe(data => {
      this.ProductsList=data;
    })
  }


  getMin(){
    this.service.GetMin();
  }

    onNgModelChange($event: any){
    console.log($event);
    this.selectedOption = $event;
    this.filterByPriceSelected(this.selectedOption);

  }

  filterByPriceSelected(selectedOption:string) {
    this.service.GetPriceSpecific(selectedOption);
  }



}
