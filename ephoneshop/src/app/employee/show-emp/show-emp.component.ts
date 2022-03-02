import { Component, OnInit } from '@angular/core';
import { EphoneAPIService } from 'src/app/ephone-api.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private services:EphoneAPIService) { }

  EmployeeList:any=[];


  ngOnInit(): void {
  }

}
