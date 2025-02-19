using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back_end.Models
{
    // Classe modelo de pessoas para envio de dados ao cliente.
    public class PessoaModel
    {
        public int Id { get; set; }

        // Definindo tamanho máximo para a string nome no banco de dados.
        [StringLength(50)]
        public string Nome { get; set; }

        // Precisamos da data de nascimento, se guardarmos apenas a idade, o código precisará de atualizações constantes.
        // Usamos JsonIgnore pois não queremos que a data de nascimento da pessoa seja retornada.
        [JsonIgnore]
        public DateTime DataNascimento { get; set; }
        
        // Idade terá apenas get, não sendo possível setar valores à ela.
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