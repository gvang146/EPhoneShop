import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DeveloperComponent } from './developer/developer.component';

const routes: Routes = [
  { path: 'products', component: ProductsComponent},
  { path: 'login', component: LoginComponent},
  { path: 'developer', component: DeveloperComponent},
  { path: '', component: HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const RoutingComponents = [ProductsComponent, LoginComponent, HomeComponent, DeveloperComponent];