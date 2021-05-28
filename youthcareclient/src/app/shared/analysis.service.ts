import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Analysis } from '../models/analysis';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AnalysisService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  public formModel = this.fb.group({
    Id: [''],
    SportsmanUserId : [''],
    DoctorUserId : [''],
    Name : [''],
    Date : [''],
    Type : [''],
    Measure : 0.0,
    Weight: 0.0,
    Height: 0.0,
    Description : [''],
    Result : false

  })

  createAnalysis() {
    var body = {
      Id : this.formModel.value.Id,
      SportsmanUserId : this.formModel.value.SportsmanUserId,
      DoctorUserId : this.formModel.value.DoctorUserId,
      Name : this.formModel.value.Name,
      Date : this.formModel.value.Date,
      Type : this.formModel.value.Type,
      Measure : this.formModel.value.Measure,
      Weight: this.formModel.value.Weight,
      Height: this.formModel.value.Height,
      Description : this.formModel.value.Description,
      Result : this.formModel.value.Result
    };
    return this.http.post(environment.baseURI + 'Analysis', body)
  }

  getCurrentUserAnalysis(id: string) {
    return this.http.get(environment.baseURI + 'AnalysisResult/' + id)
  }

  updateAnalysis(body: any) {
    body = {
      Id : this.formModel.value.Id,
      SportsmanUserId : this.formModel.value.SportsmanUserId,
      DoctorUserId : this.formModel.value.DoctorUserId,
      Name : this.formModel.value.Name,
      Date : this.formModel.value.Date,
      Type : this.formModel.value.Type,
      Measure : this.formModel.value.Measure,
      Description : this.formModel.value.Description,
      Result : this.formModel.value.Result
    }
    return this.http.put(environment.baseURI + 'AnalysisResult', body)
  }

  getAnalysis(id: string) {
    return this.http.get(environment.baseURI + 'Analysis/' + id)
  }
}
