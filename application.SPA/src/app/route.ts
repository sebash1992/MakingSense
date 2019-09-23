import {Routes} from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';

import {AuthGuard} from './_guards/auth.guard';
import {AdministratorGrantGuard} from './_guards/AdministratorGrant.Guard';
import { PostListResolver } from './_resolvers/post.list.resolver';
import { PostEditorComponent } from './Components/post-editor/post-editor.component';
import { PostEditorResolver } from './_resolvers/post.editor.resolver';

export const appRoutes: Routes = [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full',resolve: {posts: PostListResolver} },       
            { path: 'dashboard', component: DashboardComponent,resolve: {posts: PostListResolver} },     
            {
                path: '',
                runGuardsAndResolvers: 'always',
                canActivate: [AuthGuard],
                children: [
                        { path: 'editPost/:id', component: PostEditorComponent,
                            resolve: {post: PostEditorResolver}},
                ]
              },  
            { path: 'login', component: LoginComponent},  
            { path: '**', redirectTo: 'dashboard', pathMatch: 'full',resolve: {posts: PostListResolver}  }
]
