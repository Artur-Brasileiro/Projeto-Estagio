using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Dto 
{
    // Usa-se as DTO para transferir dados, iremos usar elas na criação de pessoas, transações, e também para listar de forma personalizada nossos saldos. Poderiamos usa-las também em edição, mas nesse projeto não será necessário.

    // Classe usada para criar uma nova Pessoa (Nem todos os dados são relevantes, por isso uma DTO).
    public class PessoaCriacaoDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}