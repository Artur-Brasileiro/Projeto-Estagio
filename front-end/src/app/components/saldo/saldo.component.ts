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
  totalData: TotalDto[] = [];
  displayedColumns: string[] = ['nome', 'totalReceitas', 'totalDespesas', 'saldo'];

  constructor(
    private pessoaService: PessoaService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.consultarTotal();
  }

  consultarTotal(): void {
    this.pessoaService.consultarTotal().subscribe({
      next: (resposta) => {
        // Aqui, a resposta deve conter a propriedade "dados" que é um array de TotalDto
        this.totalData = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro ao buscar saldo:', erro);
      }
    });
  }

  voltar(): void {
    this.router.navigate(['']);
  }
}