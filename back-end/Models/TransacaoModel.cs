using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using back_end.Enums;

namespace back_end.Models
{ 
    // Classe modelo de transações para o envido de dados ao cliente.
    public class TransacaoModel
    {
        public int Id { get; set; }

        // Definindo tamanho máximo da string Descricao no banco de dados.
        [StringLength(200)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        // Usa-se Enum no Tipo, para ficar claro qual Tipo estamos lidando, se fosse usado booleano, ficaria confuso o que é o Tipo 0 e o que é o Tipo 1.
        public TipoTransacaoEnum Tipo { get; set; }

        // Poderiamos passar um objeto da classe PessoaModel mas optei por pegar apenas o Id da Pessoa para facilitar meu desenvolvimento.
        public int IdPessoa { get; set; }
    }
}