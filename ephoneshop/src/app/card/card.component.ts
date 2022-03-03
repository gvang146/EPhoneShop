import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  products: Array<object> = [];
  constructor(private http: HttpService) {}
  _getProducts(): void {
    this.http.getAllProducts().subscribe((data: any) => {
      this.products = data.data;
      console.log(this.products);
    });
  }
    _addItemToCart( id: any, quantity: any): void {
      let payload = {
        productId: id,
        quantity,
      };
      this.http.addToCart(payload).subscribe(() => {
        this._getProducts();
        alert('Product Added');
      });
    }
    ngOnInit(): void {
      this._getProducts();
    }
  }






