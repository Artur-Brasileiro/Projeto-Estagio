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
  private apiUrl = 'http://localhost:5112/api/Pessoa';

  constructor(private http: HttpClient) {}

  listar(): Observable<ResponseModel<Pessoa[]>> {
    return this.http.get<ResponseModel<Pessoa[]>>(`${this.apiUrl}/Listar`);
  }

  criar(pessoa: Partial<Pessoa>): Observable<ResponseModel<Pessoa>> {
    return this.http.post<ResponseModel<Pessoa>>(`${this.apiUrl}/Criar`, pessoa);
  }

  excluir(idPessoa: number): Observable<ResponseModel<Pessoa>> {
    return this.http.delete<ResponseModel<Pessoa>>(`${this.apiUrl}/Excluir/${idPessoa}`);
  }

  consultarTotal(): Observable<ResponseModel<TotalDto[]>> {
    return this.http.get<ResponseModel<TotalDto[]>>(`${this.apiUrl}/ConsultarTotal`);
  }

  buscarPorId(id: number): Observable<ResponseModel<Pessoa>> {
    return this.http.get<ResponseModel<Pessoa>>(`${this.apiUrl}/BuscarPorId/${id}`);
  }
}