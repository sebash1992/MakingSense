import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import {AuthService} from '../_services/auth.service';

@Injectable()
export class AdministratorGrantGuard implements CanActivate {
  constructor(private user: AuthService,private router: Router) {}

  canActivate() {

    if(this.user.decodedToken.userRole != 'Administrador')
    {
       this.router.navigate(['/dashboard']);
       return false;
    }
    return true;
  }
}