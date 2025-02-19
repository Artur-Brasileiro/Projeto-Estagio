import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [MatToolbarModule, MatButtonModule, MatTableModule]
})
export class AppComponent {
  title = 'Meu Projeto Angular';

  displayedColumns: string[] = ['id', 'nome', 'email'];
  pessoas = [
    { id: 1, nome: 'Artur', email: 'artur@email.com' },
    { id: 2, nome: 'João', email: 'joao@email.com' },
    { id: 3, nome: 'Maria', email: 'maria@email.com' }
  ];
}
