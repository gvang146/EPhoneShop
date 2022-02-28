import { Component, OnInit } from '@angular/core';

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

}   
