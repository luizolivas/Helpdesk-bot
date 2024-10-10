// src/app/chat.service.ts
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ChatMessageModel } from './models/chatMessage.model';
import { Message } from './models/message.model';
import { ApiResponse } from './models/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private messagesSubject = new BehaviorSubject<ChatMessageModel[]>([]);
  messages$ = this.messagesSubject.asObservable();

  private apiUrl = 'api/Chatbot';

  constructor(private http: HttpClient) {
    const initialMessage: ChatMessageModel = {
      user: 'Lift Bot',
      text: ' Olá, este é o Suporte e Atendimento do Sistema Lift, em que posso te ajudar? (digite o número)<br />1. Erro no sistema<br />2. Dúvidas do Lift<br />3. Dúvidas do Beija-flor<br />4. Outros'    };
    this.addLocalMessage(initialMessage);
  }

  sendMessage(message: ChatMessageModel) {
    var mess : Message = {
      Content: message.text,
      Timestamp: new Date()
    }
    return this.http.post<ApiResponse>(this.apiUrl, mess)
      .pipe(
        tap(response => {
          // Adiciona a mensagem à lista de mensagens
          console.log("essa é a resposta: " , response)
          const responseMessage: ChatMessageModel = {
            user: 'Lift Bot', // ou outro identificador apropriado
            text: response.result
          };

          const currentMessages = this.messagesSubject.value;
          this.messagesSubject.next([...currentMessages, responseMessage]);
        })
      );
  }

  addLocalMessage(message: ChatMessageModel) {
    const currentMessages = this.messagesSubject.value;
    this.messagesSubject.next([...currentMessages, message]);
  }

}
