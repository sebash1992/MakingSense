import {IUserEditor} from '../../_models/User';
import {Credentials} from '../../_models/user';
import {PaginatedResult} from '../../_models/pagination';
import {HttpHeaders} from '@angular/common/http';
import {LazyLoadEvent} from 'primeng/primeng';
import { Component, OnInit,OnDestroy  } from '@angular/core';
import {HeaderService} from '../../_services/header.service';
import {AuthService} from '../../_services/auth.service';
import {AlertifyService} from '../../_services/alertify.service';
import { ActivatedRoute,Router } from '@angular/router';
import {FormBuilder, FormGroup, FormControl, Validators, NgForm} from '@angular/forms';
import { Subscription } from 'rxjs';
declare function require(path: string);
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent  implements OnInit, OnDestroy {

  imagePath = require('../../content/img/StockItLogo.png');
  private subscription: Subscription;
  isloading : boolean = false;
  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: Credentials = { userName: '', password: '' };

  constructor(private authService: AuthService, private router: Router,private activatedRoute: ActivatedRoute, private alertifyService:AlertifyService) { }

    ngOnInit() {

    // subscribe to router event
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
         this.brandNew = param['brandNew'];   
         this.credentials.userName = param['userName'];         
      });      
  }

   ngOnDestroy() {
    // prevent memory leak by unsubscribing
    this.subscription.unsubscribe();
  }

  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.isloading = true;
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
    if (valid) {
      this.authService.login(value)
        .subscribe(
        result => {         
          if (result) {
             this.isloading = false;  
             this.router.navigate(['/products']);             
          }
        },
        error =>{ 
          debugger;
          this.isloading =false;
          this.alertifyService.error(error.login_failure[0]);});
    }
  }
}