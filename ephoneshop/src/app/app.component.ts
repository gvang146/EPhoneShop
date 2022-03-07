import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './_models/UserLoginModel';
import { AuthenticationService } from './_services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ephoneshop';
  currentUser: User = new User();
  constructor (
    private router: Router,
    private authService: AuthenticationService
  ) {
        this.authService.currentUser.subscribe(x => this.currentUser = x);
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}