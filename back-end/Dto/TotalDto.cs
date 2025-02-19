using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Dto
{
    // Classe usada para retornar dados de maneira personalizada no ResponseModel
    public class TotalDto
    {
        public string Nome { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo { get; set; }
    }
}