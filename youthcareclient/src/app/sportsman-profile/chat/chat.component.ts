import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/models/pagination';
import { User } from 'src/app/models/user';
import { MessageService } from 'src/app/shared/message.service';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  messages: any = [];
  messagesToShow: any = [];
  container = 'Unread';
  pageNumber = 1;
  pageSize = 1000;
  loading = false;
  userDetails: any = [];


  constructor(private router: Router, public service: MessageService, private userService: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(
      result => {
        this.userDetails = result
        this.loadMessage(this.userDetails.userName)
      }, error => {
            console.log(error);
          }
      );
  }

  loadMessage(username: string) {
    this.loading = true;
        this.service.getMessages(this.pageNumber, this.pageSize, this.container, username).subscribe(
          result => {
            this.messages = result.result;
            this.messagesToShow = this.messages;
            this.loading = false;
    });
  }

  unreadMessage() {
    this.container = 'Unread';
  }

  inboxMessage() {
    this.container = 'Inbox';
  }

  outboxMessage() {
    this.container = 'Outbox';
  }

  public deleteMessage(id: string) {
    this.service.deleteMessage(id).subscribe()
      this.toastr.warning('A message has been deleted!');
      this.messages.splice(this.messages.findIndex((m:any) => m.id === id), 1);
  }

  onPageChange($event:any) {
    this.messagesToShow =  this.messages.slice($event.pageIndex*$event.pageSize, $event.pageIndex*$event.pageSize + $event.pageSize);
  }

}
