import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PresenceService } from 'src/app/shared/presence.service';
import { UserService } from 'src/app/shared/user.service';


@Component({
  selector: 'app-doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrls: ['./doctor-card.component.scss']
})
export class DoctorCardComponent implements OnInit {

  userDetails: any;
  doctorsList: any;
  searchText: any;

  constructor(public userService: UserService, private router: Router, public presence: PresenceService) { }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result
        this.userService.getUsersUsers(this.userDetails.belongSection.id, 'Doctor').subscribe(
          res => {
            this.doctorsList = res
          }, error => {
            console.log(error);
          }
        );
      },
      error =>{
        console.log(error);
      }
    );
  }

}
