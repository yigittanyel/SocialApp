import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormComponent } from './Comps/form/form.component';
import { NavbarComponent } from './Comps/navbar/navbar.component';
import { DenemeComponent } from './deneme/deneme.component';
import { ProductsComponent } from './Comps/products/products.component';

@NgModule({
  declarations: [
    AppComponent,
    FormComponent,
    NavbarComponent,
    DenemeComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
