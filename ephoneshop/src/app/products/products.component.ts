import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from '../ephone-api.service';
import { Cart } from '../_models/CartModel'
import { User } from '../_models/UserLoginModel';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
//creating task export for checkboxes

export class ProductsComponent implements OnInit {
  
  ProductsList:any=[];
  cartList: any =[];
  cart: Cart;
  message:string;
  currentUser: User = new User();
  filteredProducts: any[];
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
  filterBrand(selectedBrands:string[]){
    //console.log(selectedBrands);
    //console.log(this.ProductsList);
    if(selectedBrands.length==0){
      this.refreshProList();
    }
    this.service.GetProductByBrand(selectedBrands).subscribe(data =>{
      if(this.selectedProcessors != [] || this.selectedSpeeds != []){
        this.selectedProcessors = [];
        this.selectedSpeeds = [];
      }
      this.filteredProducts=data;
      this.ProductsList=this.filteredProducts;
    })
  }

  filterProcessor(selectedProcessors:string[]){
    if(selectedProcessors.length==0){
      this.refreshProList();
    }
    this.service.GetProductByProcessor(selectedProcessors).subscribe(data =>{
      if(this.selectedBrands != [] || this.selectedSpeeds != []){
        this.selectedBrands = [];
        this.selectedSpeeds = [];
      }
      this.filteredProducts=data;
      this.ProductsList=this.filteredProducts;
    })
  }

  filterSpeed(selectedSpeeds:string[]){
    if(selectedSpeeds.length==0){
      this.refreshProList();
    }
    this.service.GetProductBySpeed(selectedSpeeds).subscribe(data => {
      if(this.selectedBrands != [] || this.selectedProcessors != []){
        this.selectedBrands = [];
        this.selectedProcessors = [];
      }
      this.filteredProducts=data;
      this.ProductsList=this.filteredProducts;
    })
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


  GetCartItems(userId: string)
  {
    this.service.GetCartItems(userId).subscribe(data =>{
      this.cartList = data;
    })
  }

  //create cart of user
  CreateCartToAdd(productId: string)
  {
    //this.cart.productId = productId;
    const cartinfo = new Cart();
    cartinfo.productId = productId;
    this.AddItemToCart(cartinfo);
    if(localStorage.getItem("token") != null){
      alert("Item Successfully added to cart!");
    }else{
      alert("Log in to add an item to cart");
    }
  }

  AddItemToCart(cartInfo:Cart)
  {
    this.service.AddItemToCart(cartInfo).subscribe(data=> {
      this.message = data;
    },
    error => console.log(error));
  }
}
