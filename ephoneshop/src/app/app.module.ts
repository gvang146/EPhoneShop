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
import { CardComponent } from './card/card.component';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { ShowProComponent } from './products/show-pro/show-pro.component';
import { AddEditProComponent } from './products/add-edit-pro/add-edit-pro.component';
import { ProductsComponent } from './products/products.component';
import { EphoneAPIService } from './ephone-api.service';
import { MatCheckboxModule } from '@angular/material/checkbox';

import {HttpClientModule} from '@angular/common/http';
import { authInterceptorProviders } from './_helpers/auth.interceptor';
import { CheckoutComponent } from './checkout/checkout.component';
import { ShowCheckoutComponent } from './checkout/show-checkout/show-checkout.component';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutingComponents,
    NavbarComponent,
    CardComponent,
    ProductsComponent,
    ShowProComponent,
    AddEditProComponent,
    ShowCheckoutComponent,
    ProfileComponent
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
    FormsModule
  ],
  providers: [EphoneAPIService, authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
