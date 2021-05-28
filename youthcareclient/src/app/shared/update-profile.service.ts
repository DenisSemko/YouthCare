import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UpdateProfileService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }


  public formModel = this.fb.group({
    Name : [''],
    MiddleName : [''],
    Surname : [''],
    BirthDate : [''],
    PhoneNumber : [''],
    Address : [''],
    Username : ['', Validators.required],
    Email : ['', Validators.email],
    PasswordHash : ['', [Validators.required, Validators.minLength(8)]],
    UserType : ['']

  })

  updateProfile(body: any){
    body = {
      Name : this.formModel.value.Name,
      MiddleName : this.formModel.value.MiddleName,
      Surname : this.formModel.value.Surname,
      BirthDate : this.formModel.value.BirthDate,
      PhoneNumber : this.formModel.value.PhoneNumber,
      Address : this.formModel.value.Address,
      Username : this.formModel.value.Username,
      Email : this.formModel.value.Email,
      PasswordHash : this.formModel.value.PasswordHash,
      UserType : this.formModel.value.UserType
    };
    return this.http.put(environment.baseURI + 'Users', body)
  }
  tokenHeader = new HttpHeaders({'Authorization' : 'Bearer ' + localStorage.getItem('accessToken')});

  getUserProfile(){
    return this.http.get(environment.baseURI + 'UserProfile', {headers: this.tokenHeader});
  }
}
