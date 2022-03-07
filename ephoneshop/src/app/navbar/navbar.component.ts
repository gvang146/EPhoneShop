import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { first, Subscription } from 'rxjs';
import { User } from '../_models/UserLoginModel';
import { AuthenticationService } from '../_services/authentication.service';
import {UserService} from '../_services/UserLoginService.service';
import { LoginMessageService } from '../_services/LoginMessage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  currentUser: User = new User();
  isLoggedIn: boolean = false;
  subscription: Subscription;
  loading = false;
  users: User[] = [];
  constructor (
    private router: Router,
    private authService: AuthenticationService,
    private userService: UserService,
    private loginMessageService: LoginMessageService
  ) {
        this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
    this.subscription = this.loginMessageService.getMessage().subscribe(msg => this.isLoggedIn = msg);

    //localStorage.setItem('currentUser');
    let userInfo = localStorage.getItem('currentUser');
    if (userInfo != null)
    {
      this.isLoggedIn = true;
    }

    this.loading = true;
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.loading = false;
      this.users = users;
    })
  }
  
  ngOnDestroy():void
  {
    this.subscription.unsubscribe();
  }
  logout() {
    this.authService.logout();
    this.isLoggedIn = false;
    this.router.navigate(['/login']);
  }

}
