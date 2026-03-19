import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from './BooksComponents/Services/account.service';
import { User } from './BooksComponents/TypescriptModels/IRegister';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
 
  title = 'Client';
  loggedIn:boolean=false;
  userName :User;
  loggedInUserName:string;
  loggedinuserresponse:string;
  //currentuser$ :Observable<User|null>= of(null);
  login:any;

  private currentuser = new BehaviorSubject<User | null>(null);
  currentuser$ = this.currentuser.asObservable();

  constructor(public accountservice:AccountService,private toast:ToastrService)
  {

  }

  ngOnInit(): void {
    this.checkLoggedInUser();
  }

  checkLoggedInUser()
  {
    const userstring = localStorage.getItem('user');
    if(!userstring) return;
    {this.loggedIn = true
    const user:User = JSON.parse(userstring);
    this.currentuser.next(user)
    this.login = user;
    console.log(user.userName);
    }
  }

  logout()
  {
    localStorage.removeItem('user');
    this.currentuser.next(null);
    this.login = null;
    this.toast.show("You have successfully logged ok Out");
  }

  checkforsyncdata(event)
  {
    if(this.loggedinuserresponse == null )
    {
      this.checkLoggedInUser();
    }
  }

  UserLogin(data)
  {
     this.accountservice.loginUserforNavbar(data)
    // pipe
  //   (map((res: User) => {
  //     const user = res;
  //     this.login=res;
  //     if (user) {
  //       localStorage.setItem('user', JSON.stringify(user))
      
  //     this.currentuser.next(user)
  //     }
  // }))
     
    .subscribe({
      next:(response:User)=>{
        const user = response;
        if(user)
        {
        localStorage.setItem('user', JSON.stringify(user))
        this.currentuser.next(user)
        this.login = user;
        this.toast.success("You have succesfully logged in");
        console.log('next value retrieved is ',this.login.userName)
        }
      },
      error:(error)=>{this.toast.error(error.error)}
      

    })

  }

}
