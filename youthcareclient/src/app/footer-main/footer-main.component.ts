import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-footer-main',
  templateUrl: './footer-main.component.html',
  styleUrls: ['./footer-main.component.scss']
})
export class FooterMainComponent implements OnInit {

  constructor(private translate: TranslateService) { 
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
  }

}
