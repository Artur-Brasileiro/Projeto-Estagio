using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using back_end.Data;
using back_end.Dto;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services.Pessoa
{
    public class PessoaService : IPessoaInterface
    {
        private readonly AppDbContext context;
        public PessoaService(AppDbContext Context)
        {
            context = Context;
        }

        public async Task<ResponseModel<PessoaModel>> Criar(PessoaCriacaoDto pessoaCriacaoDto)
        {
            ResponseModel<PessoaModel> retorno = new ResponseModel<PessoaModel>();

            try
            {
                var pessoa = new TabelaPessoas
                {
                    Nome = pessoaCriacaoDto.Nome,
                    DataNascimento = pessoaCriacaoDto.DataNascimento
                };

                await context.AddAsync(pessoa);
                await context.SaveChangesAsync();

                retorno.Dados = new PessoaModel
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    DataNascimento = pessoa.DataNascimento
                };
                retorno.Mensagem = "Pessoa criada com sucesso!";

                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }

        public async Task<ResponseModel<PessoaModel>> Excluir(int idPessoa)
        {
            ResponseModel<PessoaModel> retorno = new ResponseModel<PessoaModel>();

            try
            {
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p =>
                p.Id == idPessoa);

                var transacoes = await context.Transacoes.Where(t =>
                t.IdPessoa == idPessoa).ToListAsync();

                context.Transacoes.RemoveRange(transacoes);

                context.Pessoas.Remove(pessoa);
                await context.SaveChangesAsync();

                retorno.Dados = new PessoaModel
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    DataNascimento = pessoa.DataNascimento
                };
                retorno.Mensagem = "Pessoa acima excluida com sucesso!";

                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }

        public async Task<ResponseModel<List<PessoaModel>>> Listar()
        {
            ResponseModel<List<PessoaModel>> retorno = new ResponseModel<List<PessoaModel>>();

            try
            {
                var pessoas = await context.Pessoas.Select(p => new PessoaModel
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        DataNascimento = p.DataNascimento
                    }
                ).ToListAsync();

                if (!pessoas.Any())
                {
                    retorno.Mensagem = "Nenhum registro encontrado!";
                    return retorno;
                }

                retorno.Dados = pessoas;
                retorno.Mensagem = "Pessoas listadas com sucesso!";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }
    
        public async Task<ResponseModel<List<TotalDto>>> ConsultarTotal()
        {
            ResponseModel<List<TotalDto>> retorno = new ResponseModel<List<TotalDto>>();

            try
            {
                var pessoas = await context.Pessoas.ToListAsync();
                var total = new List<TotalDto>();
                decimal totalReceitasGeral = 0, totalDespesasGeral = 0, totalSaldoGeral = 0;
                
                foreach (var pessoa in pessoas)
                {
                    var transacoes = context.Transacoes.Where(t =>
                    t.IdPessoa == pessoa.Id).ToList();

                    decimal totalReceitas = 0, totalDespesas = 0;

                    foreach (var transacao in transacoes)
                    {
                        if (transacao.Tipo == Enums.TipoTransacaoEnum.Receita)
                        {
                            totalReceitas += transacao.Valor;
                        }
                        else
                        {
                            totalDespesas += transacao.Valor;
                        }
                    }

                    decimal saldo = totalReceitas - totalDespesas;
                    total.Add(new TotalDto
                    {
                        Nome = pessoa.Nome,
                        TotalReceitas = totalReceitas,
                        TotalDespesas = totalDespesas,
                        Saldo = saldo
                    });

                    totalReceitasGeral += totalReceitas;
                    totalDespesasGeral += totalDespesas;
                    totalSaldoGeral += saldo;
                }

                total.Add(new TotalDto
                {
                    Nome = "Total Geral",
                    TotalReceitas = totalReceitasGeral,
                    TotalDespesas = totalDespesasGeral,
                    Saldo = totalSaldoGeral
                });

                retorno.Dados = total;
                retorno.Mensagem = "Totais consultados com sucesso!";
                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }
    }
}