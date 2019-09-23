import { Observable } from 'rxjs/Rx';
import { AlertifyService } from './alertify.service';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
export abstract class BaseService {  
    
    constructor() { }

    addAuthHeader(header:HttpHeaders ){
           let authToken = sessionStorage.getItem('auth_token');
           if(authToken != null){
             header = header.append('Authorization', `Bearer ${authToken}`);
         }
           return header;
     }
}