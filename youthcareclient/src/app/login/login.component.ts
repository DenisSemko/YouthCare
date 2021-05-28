import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, NgForm } from '@angular/forms';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  hide = true;
  userDetails: any;
  
  formModel = {
    Username : '',
    PasswordHash : ''
  }
  constructor(private service: UserService, private router: Router, private toastr: ToastrService, private translate: TranslateService) {
    translate.setDefaultLang('en');
  }

  ngOnInit() {
    
  }
  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res:any) => {
        localStorage.setItem('accessToken', res.accessToken);
        var inputValue = (<HTMLInputElement>document.getElementById("username")).value;
        if(inputValue.includes('admin')) 
        {
          this.router.navigateByUrl('admin/account');
        } else {
          this.service.getUserProfile().subscribe(
            result => {
              this.userDetails = result
              localStorage.setItem('type', this.userDetails.userType);
              if(this.userDetails.userType == "Sportsman") {
                this.router.navigateByUrl('sportsman/account');
              } else if(this.userDetails.userType == "Doctor") {
                this.router.navigateByUrl('doctor/account');
              }
            },
            (err: HttpErrorResponse) => {
              this.toastr.error(`${err.error.title}`);
              for(let i in err.error.errors) {
                this.toastr.error(`${err.error.errors[i]}`);
              }
              console.log(err);
            }
          );
        }
      },
      (err: HttpErrorResponse) => {
        this.toastr.error(`${err.error.title}`);
        for(let i in err.error.errors) {
          this.toastr.error(`${err.error.errors[i]}`);
        }
        console.log(err);
      }
    )
}
useLanguage(language: string): void {
  this.translate.use(language);
}

}
