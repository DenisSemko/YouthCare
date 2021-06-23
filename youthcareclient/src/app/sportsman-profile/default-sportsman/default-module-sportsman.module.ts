import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultSportsmanComponent } from 'src/app/sportsman-profile/default-sportsman/default-sportsman.component';
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
import { SharedSportsmanModule } from '../shared/shared-sportsman.module';
import { DashboardSportsmanComponent } from 'src/app/sportsman-profile/dashboard-sportsman/dashboard-sportsman.component';
import { SportsmanProfileComponent } from 'src/app/sportsman-profile/sportsman-profile/sportsman-profile.component';
import { AnalysisComponent } from 'src/app/sportsman-profile/analysis/analysis.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { InformationToolAnalysisComponent } from 'src/app/sportsman-profile/information-tool-analysis/information-tool-analysis.component';
import { ChatComponent } from 'src/app/sportsman-profile/chat/chat.component';
import { DoctorCardComponent } from 'src/app/sportsman-profile/doctor-card/doctor-card.component';
import { DoctorListComponent } from 'src/app/sportsman-profile/doctor-list/doctor-list.component';
import { NotesBodyComponent } from 'src/app/sportsman-profile/notes-body/notes-body.component';
import { SportsmanChatComponent } from 'src/app/sportsman-profile/sportsman-chat/sportsman-chat.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';


 
@NgModule({
  declarations: [
    DefaultSportsmanComponent,
    DashboardSportsmanComponent,
    SportsmanProfileComponent,
    AnalysisComponent,
    InformationToolAnalysisComponent,
    ChatComponent,
    DoctorCardComponent,
    DoctorListComponent,
    NotesBodyComponent,
    SportsmanChatComponent
  ],
  imports: [
    CommonModule,
    SharedSportsmanModule,
    RouterModule,
    MatSidenavModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatPaginatorModule,
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
    Ng2SearchPipeModule,
    MatTableModule,
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
export class DefaultModuleSportsmanModule { }
export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
