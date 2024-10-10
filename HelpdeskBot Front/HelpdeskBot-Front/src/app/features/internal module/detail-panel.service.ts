import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chamado } from '../client module/models/chamado.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DetailPanelService {

  constructor( private http: HttpClient) { }

  private apiUrl = 'api/Chamado/';

  getChamado(id: string){
    const url = `${this.apiUrl}GetChamado/${id}`
    console.log("chamado: " ,url)
    return this.http.get<Chamado>(url)
  }

  createChamado(chamado: Chamado): Observable<Chamado> {
    return this.http.post<Chamado>(`${this.apiUrl}`, chamado);
  }

  UpdateChamado(id: number, chamadoData: Chamado){
    const url = `${this.apiUrl}UpdateChamado/${id}` 
    return this.http.put(url,chamadoData)
  }
}
