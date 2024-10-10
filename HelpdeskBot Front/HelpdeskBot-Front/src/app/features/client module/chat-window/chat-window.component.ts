// src/app/chat-window/chat-window.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ChatInputComponent } from '../chat-input/chat-input.component';
import { ChatService } from '../chat.service';
import { ChatMessageModel } from '../models/chatMessage.model';

@Component({
  selector: 'app-chat-window',
  standalone: true,
  imports: [CommonModule, MatCardModule, ChatInputComponent],
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit {
  messages: ChatMessageModel[] = [];

  constructor(private chatService: ChatService) {}

  ngOnInit() {
    this.chatService.messages$.subscribe((messages) => {
      this.messages = messages;
    });
  }

  onSendMessage(message: ChatMessageModel) {
    this.chatService.addLocalMessage(message);
    this.chatService.sendMessage(message).subscribe();
  }

  
}
