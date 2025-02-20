import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PessoaService } from '../../services/pessoa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pessoa-cadastro',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './pessoa-cadastro.component.html',
  styleUrls: ['./pessoa-cadastro.component.css']
})
export class PessoaCadastroComponent implements OnInit {
  // Declaração do formulário de cadastro.
  // ! indica que a variável será inicializada depois.
  cadastroForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private pessoaService: PessoaService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Inicializa o formulário com os campos e validações.
    this.cadastroForm = this.fb.group({
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.cadastroForm.valid) {
      const novaPessoa = this.cadastroForm.value;
      this.pessoaService.criar(novaPessoa).subscribe({
        next: (resposta) => {
          console.log('Pessoa criada com sucesso:', resposta);
          // Após criar, redireciona para a lista de pessoas.
          this.router.navigate(['']);
        },
        error: (erro) => {
          console.error('Erro ao criar pessoa:', erro);
        }
      });
    }
  }

  // Navega de volta para a tela de listagem.
  cancelar(): void {
    this.router.navigate(['']);
  }
}