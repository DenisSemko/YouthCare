import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.scss']
})
export class DefaultComponent implements OnInit {

  sideBarOpen = false;

  constructor(private service: UserService) { }

  ngOnInit(): void {

  }

  sideBarToggler(event: Event) {
    this.sideBarOpen = !this.sideBarOpen;
  }

}
