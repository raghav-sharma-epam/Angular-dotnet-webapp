import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../BooksComponents/Services/account.service';
import { User } from '../BooksComponents/TypescriptModels/IRegister';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountservice: AccountService, private toastr: ToastrService, private router: Router) { }

  canActivate(): boolean | UrlTree {
    const userstring = localStorage.getItem('user');
    if (!userstring) {
      this.toastr.error('You shall Not PASS');
      return this.router.parseUrl('/login');
    }

    try {
      const user: User = JSON.parse(userstring);
      if (user) return true;
    } catch {
      // fall through to redirect
    }

    this.toastr.error('You shall Not PASS');
    return this.router.parseUrl('/login');
  }

}