import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { importProvidersFrom } from '@angular/core';

// 📌 Importando os módulos necessários
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter([]),
    importProvidersFrom(
      MatToolbarModule,
      MatButtonModule,
      MatTableModule
    )
  ]
};