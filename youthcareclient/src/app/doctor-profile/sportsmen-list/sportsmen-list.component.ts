import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/shared/user.service';
import { InformationToolSportsmenlistComponent } from '../information-tool-sportsmenlist/information-tool-sportsmenlist.component';


@Component({
  selector: 'app-sportsmen-list',
  templateUrl: './sportsmen-list.component.html',
  styleUrls: ['./sportsmen-list.component.scss']
})
export class SportsmenListComponent implements OnInit {
  userDetails: any;
  spd: any;
  users: User[]= [];
  displayedColumns: string[] = ['Id', 'Name', 'Surname', 'BirthDate', 'Email', 'Username', 'UserType'];

  dataSource = new MatTableDataSource<User>(this.users);

  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true })
  sort!: MatSort;

  constructor(public service: UserService, private toastr: ToastrService, public dialog: MatDialog, private translate: TranslateService) {
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort=this.sort;
    this.userDetailsList();

  }

  public userDetailsList() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res
        this.service.getUsersUsers(this.userDetails.belongSection.id, 'Sportsman').subscribe(
          (result) => {
            this.dataSource.data = (result as User[]);
          }, error => {
            console.log(error);
          }
        )
      },
      err =>{
        console.log(err);
      }
    );
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(InformationToolSportsmenlistComponent, {
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }


}
