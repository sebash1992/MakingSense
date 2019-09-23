import { Component, OnInit,ViewChild } from '@angular/core';
import {AlertifyService} from '../../_services/alertify.service';
import {DashboardService} from '../../_services/dashboard.service';
import { ActivatedRoute,Router } from '@angular/router';
import { BaseChartDirective } from 'ng2-charts/ng2-charts';
import {AuthService} from '../../_services/auth.service';
import { Post } from '../../_models/post';
import { PostService } from '../../_services/post.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild("baseChart")chart: BaseChartDirective;
  isLoading: boolean = false;
  today: Date;
  role: string;
  posts: Post[];
  authUser: string = '';
   
  constructor(public postService:PostService,private alertifyService: AlertifyService,public authService:AuthService,private route: Router,private router: ActivatedRoute,) {
    this.router.data.subscribe(data => {
      this.posts = data['posts'].result;
    });
    
    if(this.authService.isLoggedIn()){
      this.authUser = authService.decodedToken.id;
    }
   }

  ngOnInit() {
  }
  remove(id:string){
    this.postService.delete(id).subscribe(
      result => {
           this.alertifyService.success("Post borrado correctamente");
           this.postService.get().subscribe(
            result => {
              this.posts = result.result;
         },
         error => {
           this.alertifyService.error("Hubo un error al obtener los posts");
         })},
           
      error => {
        this.alertifyService.error("Hubo un error al borrar el post");
      });

}
  edit(id:string){
    this.route.navigate(['/editPost/'+id]);
  }
}
