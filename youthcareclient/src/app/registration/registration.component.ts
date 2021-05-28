import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  maxDateSportsman: Date;
  sectionsList: any;
  roles: string[] = ['Doctor', 'Sportsman']
  gender: string[] = ['Male', 'Female']

  constructor(public service: UserService, private toastr: ToastrService, private translate: TranslateService) { 
    const currentYear = new Date().getFullYear();
    this.maxDateSportsman = new Date(currentYear - 14, 11, 31);
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
    this.service.formModel.reset();

    this.service.getSectionsList().subscribe(
      res => {
        this.sectionsList = res
      },
      err =>{
        console.log(err);
      }
    );
  }
  onSubmit()
  {
    this.service.register().subscribe(
      (res:any) => {
          this.service.formModel.reset();
          this.toastr.success('New user has been successfully created!', 'Registration successful.');
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
