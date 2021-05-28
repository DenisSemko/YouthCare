import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { HeaderMainComponent } from './header-main/header-main.component';
import { MatDialogModule } from "@angular/material/dialog";
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card'; 
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import { RouterModule } from '@angular/router';
import { FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {MatMenuModule} from '@angular/material/menu';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { AboutMainComponent } from './about-main/about-main.component';
import { FooterMainComponent } from './footer-main/footer-main.component';
import { StatisticsMainComponent } from './statistics-main/statistics-main.component';
import { RoundedChartMainComponent } from './rounded-chart-main/rounded-chart-main.component';
import { NgxEchartsModule } from 'ngx-echarts';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { ToastrModule } from 'ngx-toastr';
import { UserService } from './shared/user.service';
import { AnalysisService } from './shared/analysis.service';
import { UpdateProfileService } from './shared/update-profile.service';
import { DefaultModule } from 'src/app/admin-profile/default/default.module';
import { DefaultModuleSportsmanModule } from 'src/app/sportsman-profile/default-sportsman/default-module-sportsman.module';
import { DefaultModuleDoctorModule } from 'src/app/doctor-profile/default-doctor/default-module-doctor.module';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient} from '@angular/common/http';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderMainComponent,
    AboutMainComponent,
    FooterMainComponent,
    StatisticsMainComponent,
    RoundedChartMainComponent,
    RegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatCardModule,
    RouterModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatGridListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatCheckboxModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  }),
    MatInputModule,
    FormsModule,
    MatSelectModule,
    MatRadioModule,
    MatFormFieldModule,
    MatIconModule,
    MatListModule,
    MatDialogModule,
    MatToolbarModule,
    DefaultModule,
    DefaultModuleSportsmanModule,
    DefaultModuleDoctorModule,
    MatButtonModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-top-right'
    }),
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts')
    })
  ],
  providers: [UserService, UpdateProfileService, AnalysisService],
  bootstrap: [AppComponent]
})
export class AppModule { }
export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
