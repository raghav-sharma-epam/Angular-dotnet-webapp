import { error } from '@angular/compiler/src/util';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  LoginForm: FormGroup;
  loginUserData:any;
  @Output() call = new EventEmitter();
  callparent : string;

  constructor(private accountservice: AccountService,
    private toastr:ToastrService
    ) {

  }

  ngOnInit(): void {
    this.LoginUser();
  }

  LoginUser() {
    this.LoginForm = new FormGroup({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }


  OnSubmit() {
    //console.log(this.Registerform.value);
    this.accountservice.loginUser(this.LoginForm.value).subscribe({
      next:(res)=>{this.loginUserData = res,
      console.log(this.loginUserData)
      },
      error:error=>{(this.toastr.error(error.error))
      console.log(error)
      },
    });
  }

  


}












