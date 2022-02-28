import { Component, OnInit } from '@angular/core';

declare var $: any;
declare var responsive_menu: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  
})


export class AppComponent  implements OnInit {  
  name = 'Jquery Integration With Angular!';  
  isJqueryWorking: any;  
  ngOnInit()  
  {  
    function PA_open() {
      document.getElementById("mySidebar").style.display = "block";
      document.getElementById("myOverlay").style.display = "block";
    }
     
    function PA_close() {
      document.getElementById("mySidebar").style.display = "none";
      document.getElementById("myOverlay").style.display = "none";
    }
    //<img id="img1" img width="400" height="400" img src="assets/Images/students2.jpg" />
    //document.getElementById("img1").src = element.src; 
    //var myImg = <HTMLInputElement>document.getElementById('img1');
    // Modal Image Gallery
    function onClick(element) {
      var myImg = <HTMLInputElement>document.getElementById('img');             
      document.getElementById("modal01").style.display = "block";
      var captionText = document.getElementById("caption");
      captionText.innerHTML = element.alt;
    }


  }  

}   
