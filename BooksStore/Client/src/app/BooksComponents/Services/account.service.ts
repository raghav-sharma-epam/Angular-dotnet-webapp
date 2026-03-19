import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Login, Register, User } from '../TypescriptModels/IRegister';
@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit {
  private currentuser = new BehaviorSubject<User | null>(null);
  currentuser$ = this.currentuser.asObservable();

  private Baseurl = "https://localhost:44395/";


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }


  registerUser(register: Register) {
    return this.http.post<Register>(this.Baseurl + 'api/Account/Register', register);

  }

  loginUser(login: Login) {
    return this.http.post<User>(this.Baseurl + 'api/Account/Login', login).pipe
      (map((res: User) => {
        const user = res;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentuser.next(user);
        }
      }))


  }


 loginUserforNavbar(login: Login): Observable<User> {
const result$: Observable<User> = this.http
.post<User>(this.Baseurl + 'api/Account/Login', login)
.pipe(
tap(res => console.log('loginUserforNavbar HTTP response payload:', res))
);
console.log('loginUserforNavbar returned observable:', result$);
return result$;
}



  SetCurrentUser(user: User) {
    this.currentuser.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentuser.next(null);
  }


}
