import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';
import { AccountService } from '../Services/account.service';
import { Register } from '../TypescriptModels/IRegister';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Registerform: FormGroup;
  RegisterUserdata:any;

  constructor(private accountservice: AccountService,private toastr:ToastrService) {

  }

  ngOnInit(): void {
    this.RegisterUser();
  }

  RegisterUser() {
    this.Registerform = new FormGroup({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      dateofbirth: new FormControl('', Validators.required),
      gender: new FormControl('', Validators.required),
      interest: new FormControl('', Validators.required),
      introduction: new FormControl('', Validators.required),
    });
  }


  OnSubmit() {
    //console.log(this.Registerform.value);
    this.accountservice.registerUser(this.Registerform.value).subscribe({
      next:(v:Register)=>{this.toastr.success("User Registered successfully"),
      this.RegisterUserdata = v
    console.log("from next result",this.RegisterUserdata)
    },
      error:(error)=>{this.toastr.error(error.error)},
      complete:()=>{console.log("complete returns",this.RegisterUserdata),
        this.Registerform.reset();
      }
    });
    // {
    //   this.toastr.success("User has been successfully registered"),
    //   this.RegisterUserdata = response,
    //   console.log(this.RegisterUserdata),
    //   error =>
    //   {
    //     this.toastr.error(error.error),
    //     console.log(error.error)

    //   }
    //   //if(user)
    //   //localStorage.setItem('RegisteredUserName',JSON.stringify(user));
    //   //console.log('data back is',this.RegisterUserdata);
    // });
  }


  //localStorage.setItem('user',this.Registerform.value);
}










