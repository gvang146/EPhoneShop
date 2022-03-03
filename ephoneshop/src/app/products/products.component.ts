import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
//creating task export for checkboxes

export class ProductsComponent implements OnInit {
  constructor() { }
  typesOfProcessors: string[] = 
  [ 
    'Level 1 Processor', 
    'Level 2 Processor', 
    'Level 3 Processor', 
    'Level 4 Processor',
    'Ravi Processor'
];
  typesOfBrand: string[] = 
  [
    'Thamsung',
    'Doogle',
    'Universe',
    'PG',
    'Enginerola',
    'Dokia'
  ];
  typesOfSpeed: string[] = 
  [ 
    '5G', 
    '4G', 
    '3G',
];
  typesOfPrice: string[] = 
  [
    '$900+',
    '$800+',
    '4700+',
    '$600+',
    '$500+',
    '$400+',
    '#300-'
  ];
  ngOnInit(): void {
  }
  
}
