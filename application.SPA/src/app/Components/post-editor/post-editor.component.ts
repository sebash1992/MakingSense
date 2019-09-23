import { Component, OnInit } from '@angular/core';
import { Post } from '../../_models/post';
import { PostService } from '../../_services/post.service';
import { AlertifyService } from '../../_services/alertify.service';
import { AuthService } from '../../_services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-editor',
  templateUrl: './post-editor.component.html',
  styleUrls: ['./post-editor.component.scss']
})
export class PostEditorComponent implements OnInit {
  ngOnInit(): void {
  }

  isloading:boolean = false;
  post: Post;
  public postForm: FormGroup;
  options:string[] = ["Activo", "Draft", "Privado"];
  optionSelected: string;

onOptionsSelected(event){
 console.log(event); //option value will be sent as event
}
  constructor(private frmbuilder: FormBuilder,public postService:PostService,private alertifyService: AlertifyService,private authService:AuthService,private route: Router,private router: ActivatedRoute,) {
    this.router.data.subscribe(data => {
      this.post = data['post'];
      this.optionSelected = this.options[0]
      this.postForm = this.frmbuilder.group({
        'title': [this.post.title, Validators.compose([Validators.required, Validators.maxLength(64)])],
        'body': [this.post.body]
      });
      });
   }
   public submit(value) {
    this.post.title = value.title;
    this.post.body = value.body;
    this.post.state = this.optionSelected;
    this.post.CreationDate = new Date();
      this.postService.post(this.post).subscribe(
            Cat => {
                if(this.post.id == ''){
                  this.alertifyService.success("Proveedor " + this.post.title + " creado correctamente.")
                }else{
                  this.alertifyService.success("Proveedor " +  this.post.title  + " editado correctamente.")
                }
                this.isloading = false;
                this.postForm.reset();
                this.route.navigate(['/dashboard']); 
            },
            err => {
                this.isloading = false;
                if(this.post.id == ''){
                  this.alertifyService.error("Proveedor " + this.post.title + " no pudo ser creado correctamente.")
                }else{
                  this.alertifyService.error("Proveedor " + this.post.title + " no pudo ser editado correctamente.")
                }
            });
  }

}
