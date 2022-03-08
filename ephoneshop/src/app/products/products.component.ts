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
  filteredProducts: any=[];
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
    'Level 3 Processor', 
    'Level 4 Processor', 
    'Level 7 Processor',
    'Level 10 Processor',
    'Ravi Processor'
];
  typesOfBrand: string[] = 
  [
    'YouPhone',
    'DamSun',
    'SoldyerSystem',
    'Notkia',
    'Enginerola',
    'Froogle'
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
    '$700+',
    '$600+',
    '$500+',
    '$400+',
    '$300-'
  ];
  
  ngOnInit(): void {
    this.refreshProList();
  }
  

  selectedBrands:string[];
  selectedProcessors:string[];
  selectedSpeeds:string[];
  selectedPrices:string[];

  merge_array(FilteredProducts:any[],Data:any[]){
    var result_array:any = [];
    var index;

    for(index in Data){
      var index2;
      var exists=false;
      for(index2 in FilteredProducts){
        if(Data[index].id == FilteredProducts[index2].id){
          exists = true;
          break;
        }else{
          exists = false;
        }
      }
      if(exists == true){
        result_array.push(Data[index])
      }

    }
    
    return result_array;
  }


  tooManyFilters:boolean=false;
  
  activeProFilter:boolean=false;
  activeBrandFilter:boolean=false;
  activeSpeedFilter:boolean=false;
  activePriceFilter:boolean=false;

  filterProcessor(selectedProcessors:string[]){
    
    if ((this.activeBrandFilter == true) || (this.activePriceFilter == true) || (this.activeSpeedFilter == true)) {
      this.service.GetProductByProcessor(selectedProcessors).subscribe(data => {
        if (this.filteredProducts == []) {
          this.tooManyFilters = true;
        } else {
            this.filteredProducts = this.merge_array(this.filteredProducts, data);
            //console.log(this.filteredProducts);
            this.ProductsList = this.filteredProducts;

          this.activeProFilter = true;
        }
      })
    } else {
      if (selectedProcessors.length == 0) {
        this.refreshProList();
        this.activeProFilter=false;
      }
      this.service.GetProductByProcessor(selectedProcessors).subscribe(data => {
        this.filteredProducts = data;
        this.ProductsList = this.filteredProducts;
        this.activeProFilter=true;

      })
    }
    
    
  }

  filterBrand(selectedBrands:string[]){
    
    if ((this.activeProFilter == true) || (this.activePriceFilter == true) || (this.activeSpeedFilter == true)) {
      this.service.GetProductByBrand(selectedBrands).subscribe(data => {
        if (this.filteredProducts == []) {
          this.tooManyFilters = true;
          this.selectedProcessors = [];
        } else {
            this.filteredProducts = this.merge_array(this.filteredProducts, data);
            //console.log(this.filteredProducts);
            this.ProductsList = this.filteredProducts;
          this.activeBrandFilter = true;
        }
      })
    } else {
      if (selectedBrands.length == 0) {
        this.refreshProList();
        this.activeBrandFilter=false;
      }
      this.service.GetProductByBrand(selectedBrands).subscribe(data => {
        this.filteredProducts = data;
        this.ProductsList = this.filteredProducts;
        this.activeBrandFilter = true;
      })
    }
  }

  filterSpeed(selectedSpeeds:string[]){
    if ((this.activeBrandFilter == true) || (this.activePriceFilter == true) || (this.activeProFilter == true)) {
      this.service.GetProductBySpeed(selectedSpeeds).subscribe(data => {
        if (this.filteredProducts == []) {
          this.tooManyFilters = true;
        } else {
            this.filteredProducts = this.merge_array(this.filteredProducts, data);
            //console.log(this.filteredProducts);
            this.ProductsList = this.filteredProducts;
          this.activeSpeedFilter = true;
        }
      })
    } else {
      if (selectedSpeeds.length == 0) {
        this.refreshProList();
        this.activeSpeedFilter=false;
      }
      this.service.GetProductBySpeed(selectedSpeeds).subscribe(data => {
        this.filteredProducts = data;
        this.ProductsList = this.filteredProducts;
        this.activeSpeedFilter = true;
      })
    }
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
}
