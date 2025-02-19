using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    // Classe modelo de resposta, ela que iremos retornar em todos os gets.
    // ResponseModel é do tipo T pois podemos receber tanto Pessoas como Transações.
    public class ResponseModel<T>
    {
        public T Dados { get; set; }
        public string Mensagem { get; set; }
    }
}