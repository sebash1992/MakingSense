import { HttpInterceptor, HttpEvent, HttpRequest, HttpErrorResponse, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { HttpHandler } from "@angular/common/http/src/backend";
import { AuthService } from "./auth.service";
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authService:AuthService){}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).catch(error => {
            if(error.status == 401){
                this.authService.logout();
            }
            if (error instanceof HttpErrorResponse) {
                const applicationError = error.headers.get('Application-Error');
                if (applicationError) {
                    return Observable.throw(applicationError);
                }
                const serverError = error.error;
                let modelStateErrors = '';
                if (serverError && serverError === 'object') {
                    for (const key in serverError) {
                        if (serverError[key]) {
                            modelStateErrors += serverError[key] + '\n';
                        }
                    }
                }
                return Observable.throw(modelStateErrors || serverError || 'Server Error');
            }
        });
    }

}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true,
};