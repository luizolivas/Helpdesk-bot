import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ImageChamado } from './client module/models/ImageChamado';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageChamadosService {

  constructor( private http: HttpClient) { }

  private apiUrl = 'api/ImageChamado/';

  getImagesById(id: number): Observable<ImageChamado[]>{
    return this.http.get<any[]>(`${this.apiUrl}${id}`);
  }

}
