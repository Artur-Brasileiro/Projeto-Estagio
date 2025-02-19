import { Routes } from '@angular/router';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { PessoaCadastroComponent } from './components/pessoa-cadastro/pessoa-cadastro.component';
import { TransacoesComponent } from './components/transacoes/transacoes.component';
import { TransacaoCadastroComponent } from './components/transacao-cadastro/transacao-cadastro.component';
import { SaldoComponent } from './components/saldo/saldo.component';

export const routes: Routes = [
  { path: '', component: PessoaComponent },
  { path: 'cadastro', component: PessoaCadastroComponent },
  { path: 'transacoes', component: TransacoesComponent },
  { path: 'transacao-cadastro', component: TransacaoCadastroComponent },
  { path: 'saldo', component: SaldoComponent }
];