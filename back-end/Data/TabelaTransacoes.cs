using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using back_end.Enums;

namespace back_end.Data
{
        // Classe usada exclusivamente para a criação da tabela Transacoes.
    public class TabelaTransacoes
    {
        public int Id { get; set; }

        // Definindo tamanho máximo para a string Descricao no banco de dados.
        [StringLength(200)]
        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        // Usa-se Enum no Tipo, para ficar claro qual Tipo estamos lidando, se fosse usado booleano, ficaria confuso o que é o Tipo 0 e o que é o Tipo 1.
        public TipoTransacaoEnum Tipo { get; set; }

        public int IdPessoa { get; set; }
    }
}