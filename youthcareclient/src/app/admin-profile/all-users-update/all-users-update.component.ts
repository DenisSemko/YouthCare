import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-all-users-update',
  templateUrl: './all-users-update.component.html',
  styleUrls: ['./all-users-update.component.scss']
})
export class AllUsersUpdateComponent implements OnInit {

  action:string;
  local_data:any;
  constructor(public dialogRef: MatDialogRef<AllUsersUpdateComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: User) { 
      console.log(data);
      this.local_data = {...data};
      this.action = this.local_data.action;
    }

    doAction(){
      this.dialogRef.close({event:this.action,data:this.local_data});
    }
  
    closeDialog(){
      this.dialogRef.close({event:'Cancel'});
    }

  ngOnInit(): void {
  }

}
