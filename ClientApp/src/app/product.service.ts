import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Model, Product } from './Model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseUrl : string = "http://localhost:7221/";

  model=new Model();

  constructor(private http : HttpClient) { }

  getName(){
    return this.model.categoryName;
  }

  getProducts() : Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl + "api/Product/getproducts/");
  }

  getProductById(id:number){
    return this.model.products.find(x=>x.Id==id);
  }

  saveProduct(product:Product){
    if(product.Id==0){
      this.model.products.push(product);
    }
    else{
      const p =this.getProductById(product.Id);
      if(p!=null){
        p.Name=product.Name;
        p.Price=product.Price;
        p.IsActive=product.IsActive;
      }
    }
  }

  deleteProduct(product:Product){
    this.model.products=this.model.products.filter(x=>x!==product);
  }

}
