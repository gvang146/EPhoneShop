import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';
import { LoginMessageService } from '../_services/LoginMessage.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  isLoggedIn: boolean;
  loginForm : any;
  loading = false;
  submitted = false;
  error = '';
  constructor
  (
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService,
    private loginMessageService: LoginMessageService

  ) { 
    if (this.authService.currentUserValue){
      this.router.navigate(['/login']);
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group ({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }
ngOnDdestroy():void
{
  
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
        this.loginMessageService.updateMessage(true);
        this.router.navigate([returnUrl]);
      },
      error: error => {
        this.error = error;
        this.loading = false;
      }
    })
  }




}
