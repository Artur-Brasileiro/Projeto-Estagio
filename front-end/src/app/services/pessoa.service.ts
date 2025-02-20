import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/response.model';
import { Pessoa } from '../models/pessoa.model';
import { TotalDto } from '../models/total.model';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {
  // URL base da API para o serviço de Pessoa
  private apiUrl = 'http://localhost:5112/api/Pessoa';

  constructor(private http: HttpClient) {}

  // Método para listar todas as pessoas.
  listar(): Observable<ResponseModel<Pessoa[]>> {
    return this.http.get<ResponseModel<Pessoa[]>>(`${this.apiUrl}/Listar`);
  }

  // Método para criar uma nova pessoa.
  criar(pessoa: Partial<Pessoa>): Observable<ResponseModel<Pessoa>> {
    return this.http.post<ResponseModel<Pessoa>>(`${this.apiUrl}/Criar`, pessoa);
  }

  // Método para excluir uma pessoa pelo ID.
  excluir(idPessoa: number): Observable<ResponseModel<Pessoa>> {
    return this.http.delete<ResponseModel<Pessoa>>(`${this.apiUrl}/Excluir/${idPessoa}`);
  }

  // Método para consultar o total de receitas, despesas e saldo.
  consultarTotal(): Observable<ResponseModel<TotalDto[]>> {
    return this.http.get<ResponseModel<TotalDto[]>>(`${this.apiUrl}/ConsultarTotal`);
  }

  // Método para buscar uma pessoa pelo ID.
  buscarPorId(id: number): Observable<ResponseModel<Pessoa>> {
    return this.http.get<ResponseModel<Pessoa>>(`${this.apiUrl}/BuscarPorId/${id}`);
  }
}