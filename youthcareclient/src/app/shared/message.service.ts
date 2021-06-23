import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { Message } from '../models/message';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  hubUrl = environment.hubUrl;
  messageReceived = new EventEmitter<Message>();
  connectionEstablished = new EventEmitter<Boolean>();  

  private connectionIsEstablished = false;  
  private hubConnection: any;  

  constructor(private fb: FormBuilder, private http: HttpClient) { 
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();  
    
  }

  sendMessageInitial(message: Message) {  
    this.hubConnection.invoke('NewMessage', message);  
  }  

  private createConnection() {  
    this.hubConnection = new HubConnectionBuilder()  
      .withUrl(this.hubUrl + 'MessageHub')
      .withAutomaticReconnect()  
      .build();  
  }  

  private startConnection(): void {  
    this.hubConnection  
      .start()  
      .then(() => {  
        this.connectionIsEstablished = true;  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch((err:any) => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout( () => { this.startConnection(); }, 5000);  
      });  
  }  

  private registerOnServerEvents(): void {  
    this.hubConnection.on('MessageReceived', (data: any) => {  
      this.messageReceived.emit(data);  
    });  
  }
  

  getMessages(pageNumber: any, pageSize: any, container: any, username: any) {
    let params = getPaginationHeaders(pageNumber, pageSize, username);
    params = params.append('Container', container);
    return getPaginatedResult<Message[]>(environment.baseURI + 'Message', params, this.http);
  }

  getMessageThread(currentUsername: string, username: string) {
    return this.http.get<Message[]>(environment.baseURI + 'Message/' + currentUsername + '/' + username);
  }

  sendMessage(currentUsername: string, username: string, content: string) {
    return this.http.post<Message>(environment.baseURI + 'Message', {SenderUsername: currentUsername, RecepientUsername: username, content})
  }
  deleteMessage(id: string) {
    return this.http.delete(environment.baseURI + 'Message/' + id)
  }

  retrieveToken() : string {
    var token = window.localStorage.getItem("accessToken")!;
    return token;
  }
}
