import { Component, OnInit, ViewChild } from '@angular/core';

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
  @ViewChild('name') inputName: any;
  @ViewChild('email') inputEmail: any;
  @ViewChild('message') inputMessage: any;
  ngOnInit()
  {


  }

   getUserContactInfo(info: any) {
    //this.service.postContactInfo(info);
    console.warn(info);
     alert("We have recieved your message " + info.Name);
     this.inputName.nativeElement.value = ' ';
     this.inputEmail.nativeElement.value = ' ';
     this.inputMessage.nativeElement.value = ' ';
  }

}
