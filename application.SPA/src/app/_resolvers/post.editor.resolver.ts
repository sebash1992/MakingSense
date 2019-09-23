import {Resolve, Router,ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import { Observable } from 'rxjs/Observable';
import {Injectable} from '@angular/core';
import {Post} from '../_models/post';
import {AlertifyService} from '../_services/alertify.service';
import {PostService} from '../_services/post.service';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';

@Injectable()
export class PostEditorResolver implements Resolve<Post>{
    constructor(private postService: PostService, private router:Router, private alertify: AlertifyService ){

    }
    resolve(route:ActivatedRouteSnapshot):Observable<Post>{
        return this.postService.getPost(route.params['id']).catch(error =>{
            this.alertify.error('A ocurrido un problema');
            return Observable.of(null);
        })
    }
}
