import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';
import { CartDetails } from 'src/app/_models/CartDetailsModel';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import { asLiteral } from '@angular/compiler/src/render3/view/util';

@Component({
  selector: 'app-shopcart',
  templateUrl: './shopcart.component.html',
  styleUrls: ['./shopcart.component.css']
})
export class ShopcartComponent implements OnInit {
  cartDetails: CartDetails[];
  displayedColumns: string[] = ['select','productName','price','quantity'];
  selection = new SelectionModel<CartDetails>(true, []);


  constructor(private service: EphoneAPIService) { }

  ngOnInit(): void {
    this.GetCartDetails();
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.cartDetails.length;
    return numSelected == numRows;
  }

  /**Select all rows if they are not selected */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }
    this.selection.select(...this.cartDetails);
  }

  /**label for checkbox */
  checkboxLabel(row?: CartDetails): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  //Update Shopping cart
  UpdateCartItem()
  {
    if (this.cartDetails != null)
    {
      let postCart = [];
      for(let i in this.cartDetails)
      {
        let snapshot:any = {
               id: this.cartDetails[i].id,
               quantity: this.cartDetails[i].quantity,
               requestDelete: this.selection.isSelected(this.cartDetails[i])
            }
        postCart.push(snapshot);
      } 
      this.service.UpdateCartItem(postCart).subscribe(
        x => console.log(x),
        err => console.log(err),
        () => this.GetCartDetails()
      );
    }
    else
    {
      alert("Cart Details is empty");
    }
  }

  //getCartDetails
  GetCartDetails()
  {
    this.service.GetCartDetails().subscribe(data => {
      this.cartDetails = data;
    })
  }

}
