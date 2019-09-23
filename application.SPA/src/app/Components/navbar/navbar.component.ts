import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  navbarOpen = false;

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }
  constructor(public authService : AuthService,private route: Router) {
    this.route.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
  };
   }
   logout(){
    this.authService.logout(); 
    this.route.navigate(['/login']); 
   }
  ngOnInit() {
  }

}
