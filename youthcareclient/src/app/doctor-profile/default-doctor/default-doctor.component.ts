import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-default-doctor',
  templateUrl: './default-doctor.component.html',
  styleUrls: ['./default-doctor.component.scss']
})
export class DefaultDoctorComponent implements OnInit {

  sideBarOpen = false;

  constructor(private service: UserService) { }

  ngOnInit(): void {
  }

  sideBarToggler(event: Event) {
    this.sideBarOpen = !this.sideBarOpen;
  }

}
