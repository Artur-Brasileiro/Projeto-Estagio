import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/response.model';
import { Transacao } from '../models/transacao.model';

@Injectable({
  providedIn: 'root'
})
export class TransacaoService {
  private apiUrl = 'http://localhost:5112/api/Transacao';

  constructor(private http: HttpClient) {}

  listar(): Observable<ResponseModel<Transacao[]>> {
    return this.http.get<ResponseModel<Transacao[]>>(`${this.apiUrl}/Listar`);
  }

  criar(transacao: Partial<Transacao>): Observable<ResponseModel<Transacao>> {
    return this.http.post<ResponseModel<Transacao>>(`${this.apiUrl}/Criar`, transacao);
  }
}