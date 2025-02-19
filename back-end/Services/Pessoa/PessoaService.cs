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
        // Criação do context para acessar o banco de dados.
        private readonly AppDbContext context;
        public PessoaService(AppDbContext Context)
        {
            context = Context;
        }

        // Todos as comunicações com o banco de dados receberão o "await".
        // A variável de retorno sempre retornará ReponseModel<PessoaModel>, por isso sempre será feito a "conversão" de TabelaPessoa para PessoaModel.

        public async Task<ResponseModel<PessoaModel>> Criar(PessoaCriacaoDto pessoaCriacaoDto)
        {
            // Criação do nosso retorno.
            ResponseModel<PessoaModel> retorno = new ResponseModel<PessoaModel>();

            // Sempre uso try cath para não quebrar a aplicação em casos de erro.
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
                // Em caso de erro não retorna dados, apenas mensagem de erro.
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }

        public async Task<ResponseModel<PessoaModel>> Excluir(int idPessoa)
        {
            ResponseModel<PessoaModel> retorno = new ResponseModel<PessoaModel>();

            try
            {
                // FirstOrDefault pega o primeiro que satisfaz a condição.
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p =>
                p.Id == idPessoa);

                // Usamos o where para recuperar transações especificas (onde o idPessoa é == idPessoa passado na função).
                // Essa função garante a lógica pedida no desafio para excluir todas as transações de pessoas excluídas.
                var transacoes = await context.Transacoes.Where(t =>
                t.IdPessoa == idPessoa).ToListAsync();

                // RemoveRange é usado para remover uma sequencia de objetos dentro de uma lista.
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
                // Select é usado para converter TabelaPessoa em PessoaModel
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
            
            // Eu compliquei um pouco além do necessário essa funcionalidade, poderia fazer apenas o saldo geral, mas também fiz o saldo individual, por isso o foreach dentro de foreach.
            
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

        public async Task<ResponseModel<PessoaModel>> BuscarPorId(int idPessoa)
        {
            ResponseModel<PessoaModel> retorno = new ResponseModel<PessoaModel>();

            try
            {
                // FirstOrDefault pega o primeiro que satisfaz a condição.
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.Id == idPessoa);

                if (pessoa == null)
                {
                    retorno.Mensagem = "Nenhuma pessoa encontrada!";
                    return retorno;
                }

                retorno.Dados = new PessoaModel
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    DataNascimento = pessoa.DataNascimento
                };
                retorno.Mensagem = "Pessoa recuperada com sucesso!";

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