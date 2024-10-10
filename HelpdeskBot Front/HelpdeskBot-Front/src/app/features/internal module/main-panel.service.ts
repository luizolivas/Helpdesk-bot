import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chamado } from '../client module/models/chamado.model';

@Injectable({
  providedIn: 'root'
})
export class MainPanelService {

  private apiUrl = 'api/Chamado';

  constructor( private http: HttpClient) { }

  getAllChamados(): Observable<Chamado[]>{
    return this.http.get<any[]>(this.apiUrl);
  }

  getChamadosById(){
    return this.http.get<Chamado[]>(this.apiUrl + '/GetChamadoIdCliente')
  }
}
