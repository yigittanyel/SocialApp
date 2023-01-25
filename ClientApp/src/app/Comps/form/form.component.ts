import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Model';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  constructor(private productService:ProductService) { }

  ngOnInit(): void {
  }
  
  addProduct(name:string,price:string,isactive:boolean){
      console.log(name);
      console.log(price);
      console.log(isactive);

      const p=new Product(0,name,price ,isactive);
      this.productService.saveProduct(p);
  }

}
