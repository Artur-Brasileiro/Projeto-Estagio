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
  transacoes: Transacao[] = [];
  displayedColumns: string[] = ['id', 'descricao', 'valor', 'tipo', 'idPessoa'];

  constructor(
    private transacaoService: TransacaoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carregarTransacoes();
  }

  carregarTransacoes(): void {
    this.transacaoService.listar().subscribe({
      next: (resposta) => {
        // Aqui você pode ajustar conforme o formato da resposta do back-end
        this.transacoes = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro ao buscar transações:', erro);
      }
    });
  }

  adicionarTransacao(): void {
    // Navega para a tela de cadastro de transações.
    // Certifique-se de criar o componente e a rota "transacao-cadastro"
    this.router.navigate(['transacao-cadastro']);
  }

  irPessoas(): void {
    // Navega de volta para a tela de listagem de pessoas (rota raiz)
    this.router.navigate(['']);
  }
}