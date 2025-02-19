using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back_end.Data
{
    // Classe usada exclusivamente para a criação da tabela Pessoas.
    public class TabelaPessoas
    {
        public int Id { get; set; }

        // Definindo tamanho máximo para a string nome no banco de dados.
        [StringLength(50)]
        public string Nome { get; set; }

        // Usamos JsonIgnore pois não queremos que a data de nascimento da pessoa seja retornada.
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