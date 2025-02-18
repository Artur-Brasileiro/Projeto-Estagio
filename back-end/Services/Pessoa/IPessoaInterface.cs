using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Dto;
using back_end.Models;

namespace back_end.Services.Pessoa
{ 
    public interface IPessoaInterface
    {
        public Task<ResponseModel<List<PessoaModel>>> Listar();
        public Task<ResponseModel<PessoaModel>> Criar(PessoaCriacaoDto pessoaCriacaoDto);
        public Task<ResponseModel<PessoaModel>> Excluir(int idPessoa);
        public Task<ResponseModel<List<TotalDto>>> ConsultarTotal();
    }
}