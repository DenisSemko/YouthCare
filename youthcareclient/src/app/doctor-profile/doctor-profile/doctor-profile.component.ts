import { Component, OnInit, ViewChild } from '@angular/core';
import { UpdateProfileService } from 'src/app/shared/update-profile.service';
import { ToastrService } from 'ngx-toastr';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
  styleUrls: ['./doctor-profile.component.scss']
})
export class DoctorProfileComponent implements OnInit {

  maxDateDoctor: Date;
  hide = true;
  userDetails: any;

  constructor(public service: UpdateProfileService, private toastr: ToastrService, private translate: TranslateService) { 
    const currentYear = new Date().getFullYear();
    this.maxDateDoctor = new Date(currentYear - 14, 11, 31);
    translate.setDefaultLang('en');
  }


  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      result => {
        this.userDetails = result
      },
      error =>{
        console.log(error);
      }
    );
  }

  onSubmit()
  {
    this.service.updateProfile(this.userDetails).subscribe( 
      result => {
        this.toastr.success('Profile updated successfully');
        window.location.reload();
      }, 
      error  => {
        console.log(error);
      }
    )

  }

}
