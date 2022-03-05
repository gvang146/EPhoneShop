import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DeveloperComponent } from './developer/developer.component';
import { SignupComponent } from './signup/signup.component';
import { CartComponent } from './components/cart/cart.component';
import { EmployeeComponent } from './employee/employee.component';
import { CustomerComponent } from './customer/customer.component';
import { CheckoutComponent } from './checkout/checkout.component';


const routes: Routes = [
  { path: 'products', component: ProductsComponent},
  { path: 'checkout', component: CheckoutComponent},
  { path: 'employee', component: EmployeeComponent},
  { path: 'customer', component: CustomerComponent},
  { path: 'login', component: LoginComponent},
  { path: 'developer', component: DeveloperComponent},
  { path: '', component: HomeComponent},
  { path: 'signup', component: SignupComponent},
  { path: 'cart', component: CartComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const RoutingComponents = [ProductsComponent, LoginComponent, HomeComponent, DeveloperComponent, SignupComponent , CheckoutComponent];
