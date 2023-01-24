import { Component, OnInit } from '@angular/core';
import { Model } from 'src/app/Model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  model=new Model();

  getName(){
    return this.model.categoryName;
  }

  getProducts(){
    return this.model.products;
  }
}
