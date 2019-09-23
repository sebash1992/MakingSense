
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import { PaginatedResult } from '../_models/pagination';
import 'rxjs/add/operator/map';
import {BaseService} from "./base.service";
import { environment } from '../../environments/environment';

@Injectable()
export class DashboardService extends BaseService {
    url = environment.baseUrl + 'api/Dashboard';
    constructor(public http: HttpClient) {
        super();
    }


}