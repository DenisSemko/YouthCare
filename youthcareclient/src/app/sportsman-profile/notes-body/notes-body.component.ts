import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NotesService } from 'src/app/shared/notes.service';
import { UUID } from 'angular2-uuid';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-notes-body',
  templateUrl: './notes-body.component.html',
  styleUrls: ['./notes-body.component.scss']
})
export class NotesBodyComponent implements OnInit {

  uuidValue: string = '';
  userDetails: any;
  noteDetails: any;
  currentDate = new Date();
  new: boolean = false;

  constructor(private router: Router, public service: NotesService, private toastr: ToastrService, public userService: UserService,
    private route: ActivatedRoute) {
   }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result
        console.log(this.currentDate);
      }, 
      error => {
        console.log(error);
      }
    );
    
    this.route.params.subscribe((params: Params) => {
      if(params.id) {
        this.noteDetails = this.service.getNotes(params.id);
        this.new = false;
      } else {
        this.new = true;
      }
    })
    
  }

  cancel() {
    this.router.navigateByUrl('/sportsman/account');
  }

  onSubmit() {
    if(this.new == true) {
      this.service.createNote().subscribe(
        result => {
          this.toastr.success('A note has been added!');
          this.router.navigateByUrl('/sportsman/account');
          this.service.formModel.reset();
        }, 
        error => {
          console.log(error);
        }
      );
    } else {
      this.service.updateNote(this.noteDetails).subscribe(
        result => {
          this.toastr.success('A note has been updated!');
          this.router.navigateByUrl('/sportsman/account');
          this.service.formModel.reset();
        }, 
        error => {
          console.log(error);
        }
      );
    }
  }

generateUUID(){
  this.uuidValue=UUID.UUID();
  return this.uuidValue;
}

}
