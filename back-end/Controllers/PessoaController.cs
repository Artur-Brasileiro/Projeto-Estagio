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
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaInterface pessoaInterface;
 
        public PessoaController(IPessoaInterface PessoaInterface)
        {
            pessoaInterface = PessoaInterface;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            var pessoas = await pessoaInterface.Listar();
            
            return Ok(pessoas);
        }

        [HttpGet("ConsultarTotal")]
        public async Task<IActionResult> ConsultarTotal()
        {
            var total = await pessoaInterface.ConsultarTotal();
            
            return Ok(total);
        }

        [HttpPost("Criar")] 
        public async Task<IActionResult> Criar(PessoaCriacaoDto pessoaCriacaoDto)
        {
            var pessoa = await pessoaInterface.Criar(pessoaCriacaoDto);
            return Ok(pessoa);
        }

        [HttpDelete("Excluir/{idPessoa}")]
        public async Task<IActionResult> Excluir(int idPessoa)
        {
            var pessoa = await pessoaInterface.Excluir(idPessoa);

            return Ok(pessoa);
        }
    }
}