import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
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
    '$900+',
    '$800+',
    '4700+',
    '$600+',
    '$500+',
    '$400+',
    '$300-'
  ];
  ngOnInit(): void {
    this.refreshProList();
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
  CreateCartToAdd(productId: any)
  {
    this.cart.productId = productId;
    this.AddItemToCart(this.cart);
  }
  AddItemToCart(cart:any)
  {
    this.service.AddItemToCart(this.cart).subscribe(data=> {
      this.message = data;
    })
  }
}


