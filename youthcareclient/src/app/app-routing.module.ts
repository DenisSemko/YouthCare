import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {StatisticsMainComponent} from './statistics-main/statistics-main.component';
import {RegistrationComponent} from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DefaultComponent } from './admin-profile/default/default.component';
import { DashboardComponent } from './admin-profile/dashboard/dashboard.component';
import { DefaultDoctorComponent } from './doctor-profile/default-doctor/default-doctor.component';
import { DashboardDoctorComponent } from './doctor-profile/dashboard-doctor/dashboard-doctor.component';
import { DefaultSportsmanComponent } from './sportsman-profile/default-sportsman/default-sportsman.component';
import { DashboardSportsmanComponent } from './sportsman-profile/dashboard-sportsman/dashboard-sportsman.component';
import { AuthGuard } from './guard/auth.guard';
import { AdminProfileComponent } from './admin-profile/admin-profile/admin-profile.component';
import { AllUsersComponent } from 'src/app/admin-profile/all-users/all-users.component';
import { SportsmanProfileComponent } from './sportsman-profile/sportsman-profile/sportsman-profile.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile/doctor-profile.component';
import { SportsmenListComponent } from './doctor-profile/sportsmen-list/sportsmen-list.component';
import { AnalysisComponent } from './sportsman-profile/analysis/analysis.component';

const routes: Routes = [
  {
    path: 'charts',
    component: StatisticsMainComponent
  },
  {
    path: 'registration',
    component: RegistrationComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin',
    component: DefaultComponent,
    children: [{
      path: 'account',
      component: DashboardComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'users',
      component: AllUsersComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'my-account',
        component: AdminProfileComponent,
        canActivate:[AuthGuard]
    }]
  },
  {
    path: 'sportsman',
    component: DefaultSportsmanComponent,
    children: [{
      path: 'account',
      component: DashboardSportsmanComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'my-account',
        component: SportsmanProfileComponent,
        canActivate:[AuthGuard]
    },
    {
      path: 'analysis',
        component: AnalysisComponent,
        canActivate:[AuthGuard]
    }]
  },
  {
    path: 'doctor',
    component: DefaultDoctorComponent,
    children: [{
      path: 'account',
      component: DashboardDoctorComponent,
      canActivate:[AuthGuard]
    },
    {
      path: 'my-account',
        component: DoctorProfileComponent,
        canActivate:[AuthGuard]
    },
    {
      path: 'sportsmen-list',
      component: SportsmenListComponent,
      canActivate:[AuthGuard]
    }]
  },
  {
    path: '',
    component: HomeComponent, 
    pathMatch: 'full'
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ scrollPositionRestoration: 'enabled', relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
