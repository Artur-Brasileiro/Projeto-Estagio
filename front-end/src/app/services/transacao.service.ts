import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/response.model';
import { Transacao } from '../models/transacao.model';

@Injectable({
  providedIn: 'root'
})
export class TransacaoService {
  // URL base da API para o serviço de Transação
  private apiUrl = 'http://localhost:5112/api/Transacao';

  constructor(private http: HttpClient) {}

  // Método para listar todas as transações
  listar(): Observable<ResponseModel<Transacao[]>> {
    return this.http.get<ResponseModel<Transacao[]>>(`${this.apiUrl}/Listar`);
  }

  // Método para criar uma nova transação
  criar(transacao: Partial<Transacao>): Observable<ResponseModel<Transacao>> {
    return this.http.post<ResponseModel<Transacao>>(`${this.apiUrl}/Criar`, transacao);
  }
}