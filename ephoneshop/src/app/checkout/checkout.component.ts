import { Component, Inject, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogCheckoutComponent } from '../components/dialog-checkout/dialog-checkout.component';
import { CartDetails } from '../_models/CartDetailsModel';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  ProductsList:any=[];
  ProductSum:any=[];
  ProductCount:any=[];
  BillForm: any;
  CCardForm: any;
  cartDetails: CartDetails[];
  totalCost: number = 0;

  constructor(private service:EphoneAPIService, private formBuilder:FormBuilder, private router: Router, public dialog: MatDialog) { }
  ngOnInit(): void {
    this.GetCartDetails();
    this.BillForm = this.formBuilder.group({
      firstName: ['',[Validators.required]],
      lastName: ['',[Validators.required]],
      email: ['',[Validators.required]],
      address: ['',[Validators.required]],
      city: ['',[Validators.required]],
      state: ['',[Validators.required]],
      zip: ['',[Validators.required]]
    })
    this.CCardForm = this.formBuilder.group({
      cardName: ['',[Validators.required]],
      cardnumber: ['',[Validators.required]],
      expmonth: ['',[Validators.required]],
      expyear: ['',[Validators.required]],
      cvv: ['',[Validators.required]]
    })
    this.refreshProList();
    this.GetTotalCost();
  }
  openDialog()
  {
    this.BillForm.reset();
    this.CCardForm.reset();
    this.dialog.open(DialogCheckoutComponent);
  }

  refreshProList(){
    this.service.GetAllProducts().subscribe(data=>{
      this.ProductsList=data;
    })
  }
  GetTotalCost()
  {
    for(var index in this.cartDetails)
    {
      this.totalCost += this.cartDetails[index].price;
    }
    
  }
  onSubmit()
  {
    this.BillForm.reset();
    this.CCardForm.reset();
    this.openDialog();
    //this.router.navigateByUrl('/products');
  }
  GetCartDetails()
  {
    this.service.GetCartDetails().subscribe(data => {
      this.cartDetails = data;
    })
  }
}
