import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioInterno } from '../client module/models/usuarioInterno';

@Injectable({
  providedIn: 'root'
})
export class UsuarioManageService {

  private apiUrl = 'api/UsuarioInterno';

  constructor( private http: HttpClient) { }

  getAllChamados(): Observable<UsuarioInterno[]>{
    return this.http.get<UsuarioInterno[]>(this.apiUrl);
  }

  getChamadosById(){
    return this.http.get<UsuarioInterno[]>(this.apiUrl + '/GetChamadoIdCliente')
  }
}
