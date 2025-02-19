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
    // Aqui estamos dizendo que essa classe é uma controller e que sua rota básica é "api/Transacao".
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        // Para termos acesso aos métods criados, precisamos de uma instância da TransacaoInterface.
        // Usa-se private readonly por questões de segurança (Encapsulamento de POO).
        private readonly ITransacaoInterface transacaoInterface;

        public TransacaoController(ITransacaoInterface TransacaoInterface)
        {
            transacaoInterface = TransacaoInterface;
        }

        // Todos as requisições são assíncronas pois os métodos são assíncronos. Em caso de um projeto onde há milhares de dados para serem lidos/escritos, isso seria importante, aqui não, mas faço pela boa prática. :D

        // Eu poderia retornar ResponseModel nas requisições, mas irei retornar IActionResult pois assim consigo ter o mesmo resultado só que agora posso enviar mensagens personalizadas para erros ja conhecidos: NotFound, Badgateway e etc.

        // Requisição HttpGet para listar as Transações, endereço: api/Transacao/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var transacao = await transacaoInterface.Listar();

            return Ok(transacao);
        }

        // Requisição HttpPost para criar uma nova Transação, endereço: api/Transacao/Criar
        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(TransacaoCriacaoDto transacaoCriacaoDto)
        {
            var transacao = await transacaoInterface.Criar(transacaoCriacaoDto);

            return Ok(transacao);
        }
    }
}