import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { AdminProfileComponent } from '../admin-profile/admin-profile.component';
import { UpdateProfileService } from 'src/app/shared/update-profile.service';
import { AllUsersUpdateComponent } from '../all-users-update/all-users-update.component';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {
  userDetails: any;
  users: User[]= [];
  displayedColumns: string[] = ['Id', 'Name', 'Surname', 'BirthDate', 'Email', 'Username', 'UserType', 'Actions'];

  dataSource = new MatTableDataSource<User>(this.users);

  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true })
  sort!: MatSort;

  constructor(public service: UserService, private toastr: ToastrService, public dialog: MatDialog, public profileService: UpdateProfileService) { }

  ngOnInit(): void {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort=this.sort;

    this.service.getAllUsers().subscribe(
      result => {
        this.dataSource.data = result as User[]
      },
      error =>{
        console.log(error);
      }
    );
  }

  public redirectToDelete = (id: string) => {
    this.service.deleteUser(id).subscribe(
      result => {
        this.toastr.success('User has been deleted!');
        window.location.reload();
      }, error => {
        console.log(error);
      }
    )
  }

  openDialog(action: any,obj: { action: any; }) {
    obj.action = action;
    const dialogRef = this.dialog.open(AllUsersUpdateComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
        console.log(result.data);
        this.profileService.updateProfile(result.data);
    });
  }

}
