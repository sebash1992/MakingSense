
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { PaginatedResult } from '../_models/pagination';
import 'rxjs/add/operator/map';
import {BaseService} from "./base.service";
import { environment } from '../../environments/environment';
import { Post } from '../_models/post';

@Injectable()
export class PostService extends BaseService {
    url = environment.baseUrl + 'api/Policy';
    constructor(public http: HttpClient) {
        super();
    }
    get() {
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
        const paginatedResult: PaginatedResult<Post[]> = new PaginatedResult<Post[]>();
        return this.http.get<Post[]>(this.url,   {headers: this.addAuthHeader(header), observe: 'response'})
        .map(response => {
            paginatedResult.result = response.body;
            //paginatedResult.totalRows = JSON.parse(response.headers.get('Pagination')).totalItems;
            return paginatedResult;
        });
    }

    getPost(id: string) {
        let header = new HttpHeaders();
        if(id == ""){
            id = "123";
        }
        header = header.append('Content-Type', 'application/json');
        return this.http.get<Post>(this.url+"/"+id,   {headers: this.addAuthHeader(header), observe: 'response'})
        .map(response => {
            return response.body;
        });
    }
    post(post: Post)
     {
        let headers = new HttpHeaders().set('Content-Type', 'application/json')        
        return this.http.post(this.url , post,  {headers: this.addAuthHeader(headers)});
    }
    delete(id:string) {
        let header = new HttpHeaders();
        header = header.append('Content-Type', 'application/json');
           return this.http.delete(this.url+"/"+id,  {headers: this.addAuthHeader(header),observe:'response'})
           .map(response => { 
               return response;
        });
    }
}