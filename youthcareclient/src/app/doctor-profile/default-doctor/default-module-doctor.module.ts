import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultDoctorComponent } from 'src/app/doctor-profile/default-doctor/default-doctor.component';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card'; 
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSelectModule} from '@angular/material/select';
import { MatDialogModule } from "@angular/material/dialog";
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { FlexLayoutModule } from "@angular/flex-layout";
import {MatCheckboxModule} from '@angular/material/checkbox';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxEchartsModule } from 'ngx-echarts';
import { FormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import { SharedDoctorModule } from '../shared/shared-doctor.module';
import { DashboardDoctorComponent } from '../dashboard-doctor/dashboard-doctor.component';
import { DoctorProfileComponent } from 'src/app/doctor-profile/doctor-profile/doctor-profile.component';
import { SportsmenListComponent } from '../sportsmen-list/sportsmen-list.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { InformationToolSportsmenlistComponent } from 'src/app/doctor-profile/information-tool-sportsmenlist/information-tool-sportsmenlist.component';
import { BlockUIModule } from 'ng-block-ui';
import { AnalysisListComponent } from 'src/app/doctor-profile/analysis-list/analysis-list.component';



@NgModule({
  declarations: [
    DefaultDoctorComponent,
    DashboardDoctorComponent,
    DoctorProfileComponent,
    SportsmenListComponent,
    InformationToolSportsmenlistComponent,
    AnalysisListComponent
  ],
  imports: [
    CommonModule,
    SharedDoctorModule,
    RouterModule,
    MatSidenavModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatRadioModule,
    MatGridListModule,
    MatDatepickerModule,
    MatSelectModule,
    MatDialogModule,
    MatToolbarModule,
    MatButtonModule,
    MatListModule,
    FlexLayoutModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    NgxEchartsModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    BlockUIModule.forRoot(),
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ]
})
export class DefaultModuleDoctorModule { }
export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
