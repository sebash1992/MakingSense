import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { PaginatedResult } from '../_models/pagination';
import { AlertifyService } from '../_services/alertify.service';
import { PostService } from '../_services/post.service';
import { HeaderService } from '../_services/header.service';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import { Post } from '../_models/post';

@Injectable()
export class PostListResolver
 implements Resolve<PaginatedResult<Post>> {
    constructor(private headerService: HeaderService, private postService: PostService,
                 private router: Router, private alertify: AlertifyService ) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<PaginatedResult<Post>> {
        return this.postService.get().catch(error => {
            this.alertify.error('A ocurrido un problema');
            //this.router.navigate(['/product']);
            return Observable.of(null);
        });
    }
}