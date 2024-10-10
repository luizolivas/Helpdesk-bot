import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chamado } from './models/chamado.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProblemReportService {

  constructor( private http: HttpClient) { }

  private apiUrl = 'api/Chamado';

  getChamados(){
    return this.http.get<Chamado>(this.apiUrl)
  }

  createChamado(chamado: Chamado): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}`, chamado);
  }

  uploadImages(idChamado : number,formData: FormData): Observable<any> {
    formData.append('chamadoId', idChamado.toString());
    return this.http.post(`api/ImageChamado`, formData);
  }
}
