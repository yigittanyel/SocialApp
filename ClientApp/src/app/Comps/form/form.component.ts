import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  addProduct(name:string,price:string,isactive:boolean){
      console.log(name);
      console.log(price);
      console.log(isactive);
  }

}
