import { ViewChild, NgZone } from '@angular/core';
import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/models/message';
import { MessageService } from 'src/app/shared/message.service';
import { UserService } from 'src/app/shared/user.service';
import { Router,ActivatedRoute } from '@angular/router';
import { MessageDto } from 'src/app/models/messageDto';

@Component({
  selector: 'app-sportsman-chat',
  templateUrl: './sportsman-chat.component.html',
  styleUrls: ['./sportsman-chat.component.scss']
})
export class SportsmanChatComponent implements OnInit {

  @ViewChild('messageForm') messageForm: any;
  @Input() messages: any = [];
  username: any;
  userDetails: any;
  messageContent: any;
  sub: any;
  message: any;
  

  constructor(public service: MessageService, public userService: UserService, private activatedRoute: ActivatedRoute, private ngZone: NgZone) { 
    this.subscribeToEvents();
  }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result;
        this.sub = this.activatedRoute.params.subscribe( 
          params => {
            this.username = params['username']
            this.loadMessages(this.userDetails.userName, this.username);
          }
        );
      });
    }

    sendMessageInitial() : void {
      if(this.messageContent) {
        this.userService.getUserProfile().subscribe(
          result => {
            this.userDetails = result
            this.sub = this.activatedRoute.params.subscribe( 
              params => {
                this.username = params['username']
              }
            );
            this.message = new Message();
            this.message.SenderUsername = this.userDetails.userName;
            this.message.RecepientUsername = this.username;
            this.message.Content = this.messageContent;
            //this.messages.push(this.message);
            this.service.sendMessageInitial(this.message);
            this.messageContent = '';
          },
          error =>{
            console.log(error);
          }
        );
        
      }
    }
    private subscribeToEvents() : void {
      this.service.messageReceived.subscribe((message: Message) => {
        this.ngZone.run(() => {
          if(message.SenderUsername !== this.username) {
            this.messages.push(message);
          }
          
        })
      })
    }

  loadMessages(currentUsername: string, username: string) {
    this.service.getMessageThread(currentUsername, username).subscribe(messages => {
      this.messages = messages;
    })
  }

}
