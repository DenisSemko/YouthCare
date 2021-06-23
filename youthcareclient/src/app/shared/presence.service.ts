import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PresenceService {

  hubUrl = environment.hubUrl;
  private hubConnection: any;
  private onlineUsersSource = new BehaviorSubject<string[]>([]);
  onlineUsers$ = this.onlineUsersSource.asObservable();

  constructor(private toastr: ToastrService, private router: Router) { }

  createHubConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl + 'presence', {
        accessTokenFactory: () => this.retrieveToken()
      })
      .withAutomaticReconnect()
      .build()

    this.hubConnection
      .start()
      .catch((error: any) => console.log(error));

    this.hubConnection.on('UserIsOnline', (username: any) => {
        this.toastr.info(username + ' has connected');
    })

    this.hubConnection.on('UserIsOffline', (username: any) => {
      this.toastr.info(username + ' has disconnected');
    })

    this.hubConnection.on('GetOnlineUsers', (usernames: string[]) => {
      this.onlineUsersSource.next(usernames);
    })
  }

  stopHubConnection() {
    this.hubConnection.stop().catch((error:any) => console.log(error));
  }

  retrieveToken() : string {
    var token = window.localStorage.getItem("accessToken")!;
    return token;
  }
}
