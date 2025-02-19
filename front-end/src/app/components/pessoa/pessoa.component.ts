import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { PessoaService } from '../../services/pessoa.service';
import { Pessoa } from '../../models/pessoa.model';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pessoa',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule],
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {
  pessoas: Pessoa[] = [];
  displayedColumns: string[] = ['id', 'nome', 'idade', 'acoes'];

  constructor(private pessoaService: PessoaService, private router: Router) {}

    ngOnInit(): void {
      this.carregarPessoas();
    }

  carregarPessoas(): void {
    this.pessoaService.listar().subscribe({
      next: (resposta) => {
        console.log('Resposta da API:', resposta);
        // Atribui os dados sem verificar a propriedade 'sucesso'
        this.pessoas = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro na requisição:', erro);
      }
    });
  }

  excluirPessoa(id: number): void {
    if (confirm('Tem certeza que deseja excluir esta pessoa?')) {
      this.pessoaService.excluir(id).subscribe({
        next: () => {
          // Atualiza o array removendo a pessoa com o id correspondente
          this.pessoas = this.pessoas.filter(pessoa => pessoa.id !== id);
        },
        error: (erro) => {
          console.error('Erro na exclusão:', erro);
        }
      });
    }
  }

  adicionarPessoa(): void {
    // Navega para a tela de cadastro
    this.router.navigate(['cadastro']);
  }

  irTransacoes(): void {
    this.router.navigate(['transacoes']);
  }
  verSaldo(): void {
    this.router.navigate(['saldo']);
  }
}