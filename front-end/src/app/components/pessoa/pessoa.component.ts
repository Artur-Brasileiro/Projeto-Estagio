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

  // Array para armazenar a lista de pessoas.
  pessoas: Pessoa[] = [];

  // Colunas a serem exibidas na tabela.
  displayedColumns: string[] = ['id', 'nome', 'idade', 'acoes'];

  constructor(private pessoaService: PessoaService, private router: Router) {}

  // Método chamado quando o componente é inicializado.
  ngOnInit(): void {
    this.carregarPessoas();
  }

  // Carrega a lista de pessoas do serviço.
  carregarPessoas(): void {
    this.pessoaService.listar().subscribe({
      next: (resposta) => {

        // Console feito para teste do código.
        console.log('Resposta da API:', resposta);

        // Atribui os dados sem verificar a propriedade 'sucesso'.
        this.pessoas = resposta.dados;
      },
      error: (erro) => {
        console.error('Erro na requisição:', erro);
      }
    });
  }

  // Exclui uma pessoa pelo ID.
  excluirPessoa(id: number): void {
    if (confirm('Tem certeza que deseja excluir esta pessoa?')) {
      this.pessoaService.excluir(id).subscribe({
        next: () => {

          // Atualiza o array removendo a pessoa com o id correspondente.
          this.pessoas = this.pessoas.filter(pessoa => pessoa.id !== id);
        },
        error: (erro) => {
          console.error('Erro na exclusão:', erro);
        }
      });
    }
  }

  // Navega para a tela de cadastro de nova pessoa.
  adicionarPessoa(): void {
    this.router.navigate(['cadastro']);
  }

  // Navega para a tela de transações.
  irTransacoes(): void {
    this.router.navigate(['transacoes']);
  }

  // Navega para a tela de saldo.
  verSaldo(): void {
    this.router.navigate(['saldo']);
  }
}