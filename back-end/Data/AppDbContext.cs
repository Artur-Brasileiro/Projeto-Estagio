using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data
{
    // Classe padrão de configuração do AppDbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // Por motivos de segurança, usamos classes separadas para a criação das tabelas do banco de dados, assim, caso haja a necessidade de uma futura alteração no banco, não precisamos arrumar o código inteiro.
        public DbSet<TabelaPessoas> Pessoas { get; set; }
        public DbSet<TabelaTransacoes> Transacoes { get; set; }
    }
}