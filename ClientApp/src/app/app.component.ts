import { Component } from '@angular/core';
import { Model } from './Model';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SocialApp';
  model=new Model();

  getName(){
    return this.model.categoryName;
  }

  getProducts(){
    return this.model.products;
  }
  
}
