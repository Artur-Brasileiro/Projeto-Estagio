using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Enums;

namespace back_end.Dto
{
    // Classe usada para criar uma nova Transacao (Nem todos os dados são relevantes, por isso uma DTO).
    public class TransacaoCriacaoDto
    {
        public string Descricao { get; set; }
        
        public decimal Valor { get; set; }

        public TipoTransacaoEnum Tipo { get; set; }

        public int IdPessoa { get; set; }
    }
}