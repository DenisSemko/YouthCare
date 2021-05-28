import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-information-tool-sportsmenlist',
  templateUrl: './information-tool-sportsmenlist.component.html',
  styleUrls: ['./information-tool-sportsmenlist.component.scss']
})
export class InformationToolSportsmenlistComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<InformationToolSportsmenlistComponent>) { }

  ngOnInit(): void {
  }

  closeModal() {
    this.dialogRef.close();
  }
}
