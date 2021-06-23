import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-sidebar-sportsman',
  templateUrl: './sidebar-sportsman.component.html',
  styleUrls: ['./sidebar-sportsman.component.scss']
})
export class SidebarSportsmanComponent implements OnInit {
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

  nextVersion() {
    this.toastr.warning("This feature will be deployed in next version!");
  }

}
