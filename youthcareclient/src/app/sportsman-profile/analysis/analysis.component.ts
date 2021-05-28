import { Component, OnInit, ViewChild } from '@angular/core';
import { AnalysisService } from 'src/app/shared/analysis.service';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { use } from 'echarts';
import { Analysis } from 'src/app/models/analysis';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { UUID } from 'angular2-uuid';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.scss']
})
export class AnalysisComponent implements OnInit {
  hide = true;
  userDetails: any;
  doctorsList: any;
  uuidValue: string = '';
  analysisName: string = '';
  currentDate = new Date();
  analysisList: Analysis[]= [];
  types: string[] = ['Temperature', 'HeartBeat', 'BreathingRate', 'SweatRate', 'BMR', 'BMI']
  displayedColumns: string[] = ['Id', 'Name', 'Date', 'Type', 'Measure', 'Description', 'Result'];

  dataSource = new MatTableDataSource<Analysis>(this.analysisList);

  @ViewChild(MatPaginator, { static: true })
  paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true })
  sort!: MatSort;

  constructor(public service: AnalysisService, private toastr: ToastrService, public userService: UserService, public dialog: MatDialog, private translate: TranslateService) { 
    translate.setDefaultLang('en');
  }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort=this.sort;

    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result
        this.getAnalysis(this.userDetails.id)
        this.userService.getUsersUsers(this.userDetails.belongSection.id, 'Doctor').subscribe(
          res => {
            this.doctorsList = res
            console.log(this.doctorsList)
          }, error => {
            console.log(error);
          }
        );
        this.analysisName = `Analysis_User_${this.userDetails.id}_${this.currentDate.getDate()}.${this.currentDate.getMonth() + 1}.${this.currentDate.getFullYear()}`;
      },
      error =>{
        console.log(error);
      }
    );

  }

  generateUUID(){
    this.uuidValue=UUID.UUID();
    return this.uuidValue;
  }

  onSubmit()
  {
    this.service.createAnalysis().subscribe( 
      result => {
        console.log(result)
        this.service.updateAnalysis(result).subscribe(
          res => {
            console.log(res)
          }
        );
        this.service.formModel.reset();
        this.toastr.success('Analysis has been created successfully!');
        window.location.reload();
      }, 
      error  => {
        console.log(error);
      }
    )

  }

  getAnalysis(id: string) {
    this.service.getCurrentUserAnalysis(id).subscribe(
      result => {
        this.dataSource.data = result as Analysis[]
      },
      error =>{
        console.log(error);
      }
    );
  }

}
