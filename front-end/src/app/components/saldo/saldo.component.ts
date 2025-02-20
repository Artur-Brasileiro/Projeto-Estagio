import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { PessoaService } from '../../services/pessoa.service';
import { TotalDto } from '../../models/total.model';

@Component({
  selector: 'app-saldo',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule],
  templateUrl: './saldo.component.html',
  styleUrls: ['./saldo.component.css']
})
export class SaldoComponent implements OnInit {

  // Array para armazenar os dados de saldo.
  totalData: TotalDto[] = [];

  // Colunas a serem exibidas na tabela.
  displayedColumns: string[] = ['nome', 'totalReceitas', 'totalDespesas', 'saldo'];

  constructor(
    private pessoaService: PessoaService,
    private router: Router
  ) {}

  // Método chamado quando o componente é inicializado.
  ngOnInit(): void {
    this.consultarTotal();
  }

  // Consulta o total de receitas, despesas e saldo.
  consultarTotal(): void {
    this.pessoaService.consultarTotal().subscribe({
      next: (resposta) => {

        // Atribui os dados da resposta ao array totalData.
        this.totalData = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro ao buscar saldo:', erro);
      }
    });
  }

  // Navega de volta para a tela anterior
  voltar(): void {
    this.router.navigate(['']);
  }
}