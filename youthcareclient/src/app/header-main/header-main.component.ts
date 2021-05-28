import { Component, OnInit, HostListener, Inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-header-main',
  templateUrl: './header-main.component.html',
  styleUrls: ['./header-main.component.scss']
})
export class HeaderMainComponent implements OnInit {

  isSticky: boolean = false;

  constructor(private translate: TranslateService) {
    translate.setDefaultLang('en');
   }

  ngOnInit(): void {
  }

  useLanguage(language: string): void {
    this.translate.use(language);
  }

}
