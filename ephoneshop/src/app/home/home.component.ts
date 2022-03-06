import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from '../ephone-api.service';

declare var $: any;
declare var responsive_menu: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})


export class HomeComponent  implements OnInit {
  name = 'Jquery Integration With Angular!';
  isJqueryWorking: any;
  ngOnInit()
  {


  }
   constructor(private service: EphoneAPIService)
  {}

/*uses the contructor service varialbe that inherits the EphonAPI to send the info retrieved from the
 form*/
  getUserContactInfo(info: any) {
    this.service.postContactInfo(info);
    console.warn(info);
    alert("We have recieved your message" + info.Name);
  }

}
