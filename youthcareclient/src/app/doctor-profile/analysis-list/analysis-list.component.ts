import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Analysis } from 'src/app/models/analysis';
import { AnalysisService } from 'src/app/shared/analysis.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-analysis-list',
  templateUrl: './analysis-list.component.html',
  styleUrls: ['./analysis-list.component.scss']
})
export class AnalysisListComponent implements OnInit {

  userDetails: any;
  spd: any;
  analysis: Analysis[]= [];
  displayedColumns: string[] = ['Id', 'Date', 'Type', 'Measure', 'Description', 'Result'];

  dataSource = new MatTableDataSource<Analysis>(this.analysis);

  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true })
  sort!: MatSort;

  constructor(public service: UserService, public analysisService: AnalysisService,  private toastr: ToastrService, public dialog: MatDialog, private translate: TranslateService) {
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort=this.sort;
    this.analysisDetailsList();

  }

  public analysisDetailsList() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res
        this.analysisService.getBySectionUserType(this.userDetails.belongSection.id, 'Sportsman').subscribe(
          (result) => {
            this.dataSource.data = (result as Analysis[]);
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

}
