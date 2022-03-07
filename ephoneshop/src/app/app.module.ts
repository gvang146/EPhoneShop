import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule, RoutingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { ProductsComponent } from './products/products.component';
import { EphoneAPIService } from './ephone-api.service';
import { MatCheckboxModule } from '@angular/material/checkbox';

import {HttpClientModule} from '@angular/common/http';

import { CheckoutComponent } from './checkout/checkout.component';
import { ShowCheckoutComponent } from './checkout/show-checkout/show-checkout.component';
import { SignupService } from './_services/SignupService.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './_services/UserLoginService.service';
import { AuthGuard } from './_utilities/auth.guard';
import { CartComponent } from './components/cart/cart.component';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    AppComponent,
    RoutingComponents,
    NavbarComponent,
    ProductsComponent,
    ShowCheckoutComponent,
    CartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatGridListModule,
    MatListModule,
    MatMenuModule,
    MatDividerModule,
    MatExpansionModule,
    HttpClientModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    FormsModule,
    MatIconModule
    
  ],
  providers: [EphoneAPIService,SignupService,UserService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
