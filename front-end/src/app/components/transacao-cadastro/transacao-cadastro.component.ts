import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { TransacaoService } from '../../services/transacao.service';
import { PessoaService } from '../../services/pessoa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transacao-cadastro',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './transacao-cadastro.component.html',
  styleUrls: ['./transacao-cadastro.component.css']
})
export class TransacaoCadastroComponent implements OnInit {
  // Declaração do formulário de cadastro.
  // ! indica que a variável será inicializada depois.
  cadastroForm!: FormGroup;

  // Tipos de transação: Receita e Despesa.
  tipos = [
    { value: 1, viewValue: 'Receita' },
    { value: 2, viewValue: 'Despesa' }
  ];

  constructor(
    private fb: FormBuilder,
    private transacaoService: TransacaoService,
    private pessoaService: PessoaService, 
    private router: Router
  ) {}

  // Método chamado quando o componente é inicializado.
  ngOnInit(): void {
    // Inicializa o formulário com os campos e validações.
    this.cadastroForm = this.fb.group({
      descricao: ['', Validators.required],
      valor: [null, [Validators.required, Validators.min(0)]],
      tipo: [null, Validators.required],
      idPessoa: [null, Validators.required] 
    });
  }

  // Método chamado ao submeter o formulário.
  onSubmit(): void {
    if (this.cadastroForm.valid) {
      const novaTransacao = this.cadastroForm.value;
      
      // Lógica de validação: se a pessoa for menor de 18 anos, não pode ter receita.
      // Vamos recuperar os dados da pessoa através do endpoint BuscarPorId.
      this.pessoaService.buscarPorId(novaTransacao.idPessoa).subscribe({
        next: (response) => {
          const pessoa = response.dados;
          console.log('Pessoa retornada:', pessoa);
          if (pessoa.idade < 18 && novaTransacao.tipo === 1) {
            alert("Para pessoas menores de 18 anos, apenas despesas são permitidas.");
            return;
          }
          // Se a validação passar, envia a transação.
          this.transacaoService.criar(novaTransacao).subscribe({
            next: (resposta) => {
              console.log('Transação criada com sucesso:', resposta);
              this.router.navigate(['transacoes']);
            },
            error: (erro) => {
              console.error('Erro ao criar transação:', erro);
            }
          });
        },
        error: (erro) => {
          console.error('Erro ao buscar pessoa:', erro);
          alert("Não foi possível verificar os dados da pessoa.");
        }
      });
    }
  }
  
  // Método chamado ao cancelar o cadastro
  cancelar(): void {
    // Volta para a tela de transações
    this.router.navigate(['transacoes']);
  }
}
