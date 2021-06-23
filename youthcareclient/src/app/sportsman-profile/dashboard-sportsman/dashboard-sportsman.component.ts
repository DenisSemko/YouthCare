import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AnalysisService } from 'src/app/shared/analysis.service';
import { NotesService } from 'src/app/shared/notes.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-dashboard-sportsman',
  templateUrl: './dashboard-sportsman.component.html',
  styleUrls: ['./dashboard-sportsman.component.scss']
})
export class DashboardSportsmanComponent implements OnInit {

  notesDetails: any;
  userDetails: any;
  @ViewChild('truncator') truncator: ElementRef<HTMLElement> | undefined;
  htmlVariable: string = "<br>";

  constructor(public service: NotesService, private userService: UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result
        this.getNotesList(this.userDetails.id)
      },
      error => {
        console.log(error);
      }
    );
    
  }

  getNotesList(id: string) {
    this.service.getNotes(id).subscribe(
      result => {
        this.notesDetails = result
        console.log(this.notesDetails)
      },
      error =>{
        console.log(error);
      }
    );
  }

  public deleteNoteById(id: string) {
    this.service.deleteNote(id).subscribe(
      result => {
        this.toastr.warning('A note has been deleted!');
        window.location.reload();
      },
      error => {
        console.log(error);
      }
    )
  }

}
