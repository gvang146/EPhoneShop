import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm : any;
  loading = false;
  submitted = false;
  error = '';
  constructor
  (
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService

  ) { 
    if (this.authService.currentUserValue){
      this.router.navigate(['/login']);
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group ({
      Email: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  get f() {return this.loginForm.controls}
  onSubmit()
  {
    this.submitted = true;
    //stop here if form is invalid
    if (this.loginForm.invalid)
    {
      return;
    }
    this.loading = true;
    this.authService.login(this.f['Username'].value, this.f['Password'].value)
    .pipe(first())
    .subscribe({
      next: () => {
        // get reutrn url from route paramters or defaults to '/'
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.router.navigate([returnUrl]);
      },
      error: error => {
        this.error = error;
        this.loading = false;
      }
    })
  }




}
