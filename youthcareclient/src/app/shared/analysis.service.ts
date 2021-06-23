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

  public formModelDetection = this.fb.group({
    Id: [''],
    SportsmanId : [''],
    DoctorId : [''],
    AnalysisType : ['']
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
    return this.http.post(environment.baseURI + '/Analysis', body)
  }

  getCurrentUserAnalysis(id: string) {
    return this.http.get(environment.baseURI + '/AnalysisResult/' + id)
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
      Weight: this.formModel.value.Weight,
      Height: this.formModel.value.Height,
      Description : this.formModel.value.Description,
      Result : this.formModel.value.Result
    }
    return this.http.put(environment.baseURI + '/AnalysisResult', body)
  }

  updateAnalysisAfterDetection(body: any) {
    return this.http.put(environment.baseURI + '/AnalysisAfterDetection', body)
  }

  getAnalysis(id: string) {
    return this.http.get(environment.baseURI + '/Analysis/' + id)
  }

  createAnalysisDetection() {
    var body = {
      Id : this.formModelDetection.value.Id,
      SportsmanId : this.formModelDetection.value.SportsmanId,
      DoctorId: this.formModelDetection.value.DoctorId,
      AnalysisType : this.formModelDetection.value.AnalysisType
    }
    return this.http.post(environment.baseURI + '/AnalysisDetection', body)
  }

  getAnalysisDetection() {
    return this.http.get(environment.baseURI + '/AnalysisDetection')
  }

  deleteAnalysisDetection(id: string) {
    return this.http.delete(environment.baseURI + '/AnalysisDetection/' + id);
  }

  getAfterAnalysisDetection(id: string) {
    return this.http.get(environment.baseURI + '/AnalysisAfterDetection/' + id);
  }
  
  getBySectionUserType(id: string, type: string) {
    return this.http.get(environment.baseURI + '/Analysis/' + id + '/' + type)
  }
}
