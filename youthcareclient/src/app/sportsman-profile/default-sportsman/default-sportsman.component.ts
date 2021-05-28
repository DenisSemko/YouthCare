import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-default-sportsman',
  templateUrl: './default-sportsman.component.html',
  styleUrls: ['./default-sportsman.component.scss']
})
export class DefaultSportsmanComponent implements OnInit {

  sideBarOpen = false;

  constructor(private service: UserService) { }

  ngOnInit(): void {
  }

  sideBarToggler(event: Event) {
    this.sideBarOpen = !this.sideBarOpen;
  }

}
