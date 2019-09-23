import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import {AuthService} from '../_services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private user: AuthService,private router: Router) {}

  canActivate() {
    if(!this.user.isLoggedIn())
    {
       this.router.navigate(['/login']);
       return false;
    }

    return true;
  }
}