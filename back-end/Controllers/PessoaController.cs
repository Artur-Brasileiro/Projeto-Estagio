using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Dto;
using back_end.Models;
using back_end.Services.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    // Aqui estamos dizendo que essa classe é uma controller e que sua rota básica é "api/Pessoa".
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase // Controller sempre herda de ControllerBase
    {
        // Para termos acesso aos métods criados, precisamos de uma instância da PessoaInterface.
        // Usa-se private readonly por questões de segurança (Encapsulamento de POO).
        private readonly IPessoaInterface pessoaInterface;
 
        public PessoaController(IPessoaInterface PessoaInterface)
        {
            pessoaInterface = PessoaInterface;
        }

        // Todos as requisições são assíncronas pois os métodos são assíncronos. Em caso de um projeto onde há milhares de dados para serem lidos/escritos, isso seria importante, aqui não, mas faço pela boa prática. :D

        // Eu poderia retornar ResponseModel nas requisições, mas irei retornar IActionResult pois assim consigo ter o mesmo resultado só que agora posso enviar mensagens personalizadas para erros ja conhecidos: NotFound, Badgateway e etc.

        // Requisição HttpGet para listar as pessoas, endereço: api/Pessoa/Listar
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var pessoas = await pessoaInterface.Listar();
            
            return Ok(pessoas);
        }

        // Requisição HttpGet para buscar uma pessoa por Id, endereço: api/Pessoa/BuscarPorId
        [HttpGet("BuscarPorId/{idPessoa}")]
        public async Task<IActionResult> BuscarPorId(int idPessoa)
        {
            var pessoa = await pessoaInterface.BuscarPorId(idPessoa);
            return Ok(pessoa);
        }

        // Requisição HttpGet para retornar o saldo de todo mundo e o geral, endereço: api/Pessoa/ConsultarTotal
        // Fiquei em dúvida se colocava essa requisição na parte de transação, mas como a lógica deve percorrer por toda a lista de pessoas, julguei certo colocar aqui.
        [HttpGet("ConsultarTotal")]
        public async Task<IActionResult> ConsultarTotal()
        {
            var total = await pessoaInterface.ConsultarTotal();
            
            return Ok(total);
        }

        // Requisição HttpPost para criar uma nova Pessoa, endereço: api/Pessoa/Criar
        [HttpPost("Criar")] 
        public async Task<IActionResult> Criar(PessoaCriacaoDto pessoaCriacaoDto)
        {
            var pessoa = await pessoaInterface.Criar(pessoaCriacaoDto);
            return Ok(pessoa);
        }

        // Requisição HttpDelete para deletar uma Pessoa, endereço: api/Pessoa/Deletar
        [HttpDelete("Excluir/{idPessoa}")]
        public async Task<IActionResult> Excluir(int idPessoa)
        {
            var pessoa = await pessoaInterface.Excluir(idPessoa);

            return Ok(pessoa);
        }
    }
}