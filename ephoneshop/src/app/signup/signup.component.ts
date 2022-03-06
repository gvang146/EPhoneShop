import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from '../ephone-api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private service:EphoneAPIService,private route:Router) { }


  FirstName:string="";
  LastName:string="";
  Email:string="";
  pass:string="";


  ngOnInit(): void {
  }

  addCustomer(){
    var val = { FirstName:this.FirstName,
                LastName:this.LastName,
                Email:this.Email,
                pass:this.pass};
    this.service.addCustomer(val).subscribe(res=>{
      alert("Welcome " + this.FirstName + "! Please browse for a product you want.");
    });

    this.route.navigate(['/products']);
  }
}
