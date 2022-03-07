import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserSignUpModel } from '../_models/UserSignupModel';
import { SignupService } from '../_services/SignupService.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  data = false;
  UserForm: any;
  message: string ='';

  constructor(private formBuilder:FormBuilder, private signupService: SignupService, private router: Router) { }

  ngOnInit(): void {
    this.UserForm = this.formBuilder.group({
      FirstName: ['',[Validators.required]],
      LastName: ['',[Validators.required]],
      Email: ['',[Validators.required]],
      Password: ['',[Validators.required]]
    })
  }
  onSubmit()
  {
    const user = this.UserForm.value;
    
    this.CreateUser(user);
    this.router.navigate(['/login']);
    
  }
  CreateUser(user: UserSignUpModel)
  {
    this.signupService.CreateUser(user).subscribe(
      () =>
      {
        this.data = true;
        this.message = 'Account has been added successfully';
        this.UserForm.reset();
        alert(this.message);
      });
  }
}