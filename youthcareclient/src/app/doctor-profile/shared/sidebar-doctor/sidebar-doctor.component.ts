import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-sidebar-doctor',
  templateUrl: './sidebar-doctor.component.html',
  styleUrls: ['./sidebar-doctor.component.scss']
})
export class SidebarDoctorComponent implements OnInit {
  userDetails: any;
  url = '';

  constructor(private router: Router, private service: UserService, private toastr: ToastrService, private translate: TranslateService) {
    translate.setDefaultLang('en');
  }
  OnSelectFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); 

      reader.onload = (event) => { 
        this.url = <string>reader.result;
      }
    }
  }
  ngOnInit(){
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res
      },
      err =>{
        console.log(err);
      }
    );
  };

}
