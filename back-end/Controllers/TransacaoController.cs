using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Dto;
using back_end.Services.Transacao;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoInterface transacaoInterface;

        public TransacaoController(ITransacaoInterface TransacaoInterface)
        {
            transacaoInterface = TransacaoInterface;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var transacao = await transacaoInterface.Listar();

            return Ok(transacao);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(TransacaoCriacaoDto transacaoCriacaoDto)
        {
            var transacao = await transacaoInterface.Criar(transacaoCriacaoDto);

            return Ok(transacao);
        }
    }
}