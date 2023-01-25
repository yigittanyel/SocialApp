import { Component, OnInit } from '@angular/core';
import { Model, Product } from 'src/app/Model';
import { ProductService } from 'src/app/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  selectedProduct!: Product;
  products: Product[];
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(){
     this.productService.getProducts().subscribe(products=>{
        this.products=products
    });
  }

  onSelectProduct(product:Product ){
    this.selectedProduct=product;
  }

  deleteProducts(product:Product) {
     this.productService.deleteProduct(product);
  }
}
