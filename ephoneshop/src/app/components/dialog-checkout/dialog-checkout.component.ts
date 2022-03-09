import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EphoneAPIService } from 'src/app/ephone-api.service';
@Component({
  selector: 'app-dialog-checkout',
  templateUrl: './dialog-checkout.component.html',
  styleUrls: ['./dialog-checkout.component.css']
})
export class DialogCheckoutComponent implements OnInit {

  constructor(public dialog: MatDialog, private router: Router, private service: EphoneAPIService) { }

  ngOnInit(): void {
  }

  onClick()
  {
    this.service.DeleteAllCartItems();
    this.dialog.closeAll()
    this.router.navigateByUrl("/products");
  }
}
