import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  public formModel = this.fb.group({
    Name : [''],
    Surname : [''],
    BirthDate : [''],
    Gender : [''],
    Username : ['', Validators.required],
    Email : ['', Validators.email],
    PasswordHash : ['', [Validators.required, Validators.minLength(8)]],
    BelongSection : [''],
    ProfilePicture : [''],
    UserType : ['']

  })
  register(){
    var body = {
      Name : this.formModel.value.Name,
      Surname : this.formModel.value.Surname,
      BirthDate : this.formModel.value.BirthDate,
      Gender : this.formModel.value.Gender,
      Username : this.formModel.value.Username,
      Email : this.formModel.value.Email,
      PasswordHash : this.formModel.value.PasswordHash,
      BelongSection : this.formModel.value.BelongSection,
      ProfilePicture : this.formModel.value.ProfilePicture,
      UserType : this.formModel.value.UserType
    };
    return this.http.post(environment.baseURI + 'UserAuth/registration', body)
  }
  tokenHeader = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('accessToken')});

  login(formData: any){
    return this.http.post(environment.baseURI + 'UserAuth/login', formData);
  }

  getSectionsList() {
    return this.http.get(environment.baseURI + 'Section')
  }

  getAllUsers() {
    return this.http.get(environment.baseURI + 'Users')
  }

  getUserProfile(){
    return this.http.get(environment.baseURI + 'UserProfile', {headers: this.tokenHeader});
  }

  getSystemBackup() {
    return this.http.get(environment.baseURI + 'Backup', {headers: this.tokenHeader});
  }

  deleteUser(id: string) {
    return this.http.delete(environment.baseURI + 'Users/' + id, {headers: this.tokenHeader})
  }

  getAllUsersUsers() {
    return this.http.get(environment.baseURI +'UsersUsers')
  }

  getUsersUsers(id: string, type: string) {
    return this.http.get(environment.baseURI + 'UsersUsers/' + id + '/' + type)
  }

}
