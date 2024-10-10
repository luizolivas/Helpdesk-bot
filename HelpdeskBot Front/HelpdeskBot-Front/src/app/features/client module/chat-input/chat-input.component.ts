// src/app/chat-input/chat-input.component.ts
import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ChatService } from '../chat.service';
import { UserService } from '../user.service';
import { ChatMessageModel } from '../models/chatMessage.model';

@Component({
  selector: 'app-chat-input',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './chat-input.component.html',
  styleUrls: ['./chat-input.component.css']
})
export class ChatInputComponent {
  @Output() sendMessage = new EventEmitter<ChatMessageModel>();
  inputText: string = '';

  constructor(private userService: UserService) {}

  send() {
    this.userService.setUserName('Luiz');
    const userName = this.userService.getUserName();

    if (this.inputText.trim()) {
      const message: ChatMessageModel = {
        user: userName,
        text: this.inputText
      };
      this.sendMessage.emit(message);
      this.inputText = '';
    }
  }
}
