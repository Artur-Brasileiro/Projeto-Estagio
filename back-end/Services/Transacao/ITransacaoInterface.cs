using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Dto;
using back_end.Models;

namespace back_end.Services.Transacao
{
    // Vamos usar Interface para diminuir a responsabilidade das classes.
    // Todos os métodos retornam uma Task pois eu quero que sejam assíncronos.
    public interface ITransacaoInterface
    {
        public Task<ResponseModel<List<TransacaoModel>>> Listar();
        public Task<ResponseModel<TransacaoModel>> Criar(TransacaoCriacaoDto transacaoCriacaoDto);
    }
}