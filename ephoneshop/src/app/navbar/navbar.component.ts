import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { User } from '../_models/UserLoginModel';
import {UserService} from '../_services/UserLoginService.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn = false;
  loading = false;
  users: User[] = [];
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loading = true;
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.loading = false;
      this.users = users;
    })
  }

}
