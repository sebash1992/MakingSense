
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {IUser,IUserEditor,IAuthUser,Credentials} from '../_models/user';
import { PaginatedResult } from '../_models/pagination';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/Rx'; 
import { environment } from '../../environments/environment';
import {tokenNotExpired,JwtHelper} from 'angular2-jwt';
import { ActivatedRoute,Router } from '@angular/router';
@Injectable()
export class AuthService {
    url = environment.baseUrl + 'api/Auth';
    private loggedIn = false;
    decodedToken: any;
    jwtHelper:JwtHelper = new JwtHelper();
      // Observable navItem source
     private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
     authNavStatus$ = this._authNavStatusSource.asObservable();



    constructor(public http: HttpClient,private route: Router,) {
        this.loggedIn = !!sessionStorage.getItem('auth_token');
        this._authNavStatusSource.next(this.loggedIn);
    }

        login(credentials: Credentials) {
            let headers = new HttpHeaders();
            headers = headers.append('Content-Type', 'application/json');
            headers = headers.append('access-control-allow-origin: *', 'charset=utf-8');
            return this.http.post<IAuthUser>(this.url + '/login',credentials,{headers: new HttpHeaders()
            .set('Content-Type', 'application/json')})
            .map(res => {
                sessionStorage.setItem('auth_token', res.auth_token);            
                this.decodedToken = this.jwtHelper.decodeToken(res.auth_token);    
                console.log(this.decodedToken);
                this._authNavStatusSource.next(true);
                this.loggedIn = true;
                return true;
            });
        }

          logout() {
                sessionStorage.removeItem('auth_token');                
                this._authNavStatusSource.next(false);
                this.loggedIn = false;
                this.route.navigate(['/dashboard']); 
            }

            isLoggedIn() {
                return this.loggedIn;
            }
}