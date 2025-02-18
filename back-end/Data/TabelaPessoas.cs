using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back_end.Data
{
    public class TabelaPessoas
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [JsonIgnore]
        public DateTime DataNascimento { get; set; }
        
        public int Idade 
        { 
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DataNascimento.Year;

                if (DataNascimento.Date > hoje.AddYears(-idade))
                {
                    idade--;
                }

                return idade;
            }
        }
    }
}