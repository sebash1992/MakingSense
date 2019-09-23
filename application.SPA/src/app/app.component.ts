import { Component, OnInit } from '@angular/core';
import {AuthService} from './_services/auth.service';
import { JwtHelper } from 'angular2-jwt';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  jwtHelper: JwtHelper = new JwtHelper();
  subscription:Subscription;
  public islogged = false;
  status: boolean;
  constructor (public authService: AuthService){}
  ngOnInit(){
    this.subscription = this.authService.authNavStatus$.subscribe(status =>{ this.status = status

      });
    const token = sessionStorage.getItem('auth_token');
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}
