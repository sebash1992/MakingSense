import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoadingComponent } from './common/loading/loading.component';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';


import {AlertifyService} from './_services/alertify.service';
import {HeaderService} from './_services/header.service';
import {AuthService} from './_services/auth.service';
import {DashboardService} from './_services/dashboard.service';
import {PostService} from './_services/post.service';

import {NavDropdownDirective,NavDropdownToggleDirective} from './_directives/sideBar.dropdown.directive';

import {ErrorInterceptor,ErrorInterceptorProvider} from './_services/error.interceptor';

import {AuthGuard} from './_guards/auth.guard';
import {AdministratorGrantGuard} from './_guards/AdministratorGrant.Guard';

import {RouterModule} from '@angular/router';
import {appRoutes} from './route';

import {DataTableModule} from 'primeng/datatable';
import {DropdownModule} from 'primeng/dropdown';
import {DialogModule} from 'primeng/dialog';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {ToggleButtonModule} from 'primeng/togglebutton';
import {CheckboxModule} from 'primeng/checkbox';

import { CookieService } from 'angular2-cookie/services/cookies.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import {ReactiveFormsModule} from '@angular/forms';
import { FileUploadModule } from 'ng2-file-upload';
import { ChartsModule } from 'ng2-charts';
import { NgxBarcodeModule } from 'ngx-barcode';
import {CalendarModule} from 'primeng/calendar';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { PostListResolver } from './_resolvers/post.list.resolver';
import { PostEditorComponent } from './Components/post-editor/post-editor.component';
import { PostEditorResolver } from './_resolvers/post.editor.resolver';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoadingComponent,
    LoginComponent,
    NavDropdownDirective,
    NavDropdownToggleDirective,
    NavbarComponent,
    PostEditorComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    DataTableModule,
    DropdownModule,
    ReactiveFormsModule,
    DialogModule,
    AutoCompleteModule,
    ToggleButtonModule,
    ChartsModule,
    CheckboxModule,
    NgxBarcodeModule,
    FileUploadModule,
    CalendarModule
  ],
  providers: [
    PostEditorResolver,
    PostListResolver,
    CookieService,
    PostService,
    AlertifyService,
    HeaderService,
    AuthService,
    DashboardService,
    AuthGuard,
    AdministratorGrantGuard,
    ErrorInterceptorProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
