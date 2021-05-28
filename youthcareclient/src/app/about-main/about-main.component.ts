import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-about-main',
  templateUrl: './about-main.component.html',
  styleUrls: ['./about-main.component.scss']
})
export class AboutMainComponent implements OnInit {

  constructor(private translate: TranslateService) { 
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
  }

}
