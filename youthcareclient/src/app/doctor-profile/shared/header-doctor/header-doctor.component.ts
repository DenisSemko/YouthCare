import { Component, EventEmitter, OnInit, Output, LOCALE_ID, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header-doctor',
  templateUrl: './header-doctor.component.html',
  styleUrls: ['./header-doctor.component.scss']
})
export class HeaderDoctorComponent implements OnInit {

  @Output() toggleSideBarForMe: EventEmitter<any> = new EventEmitter();

  constructor(private router: Router, private toastr: ToastrService, @Inject(LOCALE_ID) protected localeId: string, private translate: TranslateService) {
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
  }

  toggleSideBar(){
    this.toggleSideBarForMe.emit();
  }
  onLogout(){
    localStorage.removeItem('accessToken');
    localStorage.removeItem('type');
    this.router.navigateByUrl('/login');
  }
  profileWarning() {
    this.toastr.warning('Please update your profile with the detailed information!', 'Update Profile');
  }
  btnClick() {
    this.router.navigateByUrl('doctor/my-account');
  }
  useLanguage(language: string): void {
    this.translate.use(language);
  }

}
