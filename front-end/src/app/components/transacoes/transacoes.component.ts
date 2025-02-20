import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { TransacaoService } from '../../services/transacao.service';
import { Transacao, TipoTransacaoEnum } from '../../models/transacao.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transacoes',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule],
  templateUrl: './transacoes.component.html',
  styleUrls: ['./transacoes.component.css']
})
export class TransacoesComponent implements OnInit {

  // Array para armazenar a lista de transações.
  transacoes: Transacao[] = [];

  // Colunas a serem exibidas na tabela.
  displayedColumns: string[] = ['id', 'descricao', 'valor', 'tipo', 'idPessoa'];

  constructor(
    private transacaoService: TransacaoService,
    private router: Router
  ) {}

  // Método chamado quando o componente é inicializado.
  ngOnInit(): void {
    this.carregarTransacoes();
  }

  // Carrega a lista de transações do serviço.
  carregarTransacoes(): void {
    this.transacaoService.listar().subscribe({
      next: (resposta) => {
        this.transacoes = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro ao buscar transações:', erro);
      }
    });
  }

  // Navega para a tela de cadastro de transações.
  adicionarTransacao(): void {
    this.router.navigate(['transacao-cadastro']);
  }

  // Navega de volta para a tela de listagem de pessoas.
  irPessoas(): void {
    this.router.navigate(['']);
  }
}