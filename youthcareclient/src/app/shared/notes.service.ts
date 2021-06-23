import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  public formModel = this.fb.group({
    Id: [''],
    SportsmanUserId : [''],
    Title : [''],
    Description : [''],
    Date : ['']
  })

  createNote() {
    var body = {
      Id : this.formModel.value.Id,
      SportsmanUserId : this.formModel.value.SportsmanUserId,
      Title : this.formModel.value.Title,
      Description : this.formModel.value.Description
    };
    return this.http.post(environment.baseURI + '/SportsmanNote', body)
  }

  getNotes(id: string) {
    return this.http.get(environment.baseURI + '/SportsmanNote/'+ id)
  }

  updateNote(body: any){
    body = {
      Id : this.formModel.value.Id,
      SportsmanUserId : this.formModel.value.SportsmanUserId,
      Title : this.formModel.value.Title,
      Description : this.formModel.value.Description
    };
    return this.http.put(environment.baseURI + '/SportsmanNote', body)
  }

  deleteNote(id: string) {
    return this.http.delete(environment.baseURI + '/SportsmanNote/' + id)
  }
}
