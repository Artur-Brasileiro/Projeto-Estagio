using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Data;
using back_end.Dto;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services.Transacao
{
    public class TransacaoService : ITransacaoInterface
    {
        private readonly AppDbContext context;

        public TransacaoService(AppDbContext Context)
        {
            context = Context;
        }

        public async Task<ResponseModel<TransacaoModel>> Criar(TransacaoCriacaoDto transacaoCriacaoDto)
        {
            ResponseModel<TransacaoModel> retorno = new ResponseModel<TransacaoModel>();

            try
            {
                var pessoa = await context.Pessoas.FirstOrDefaultAsync(p =>
                p.Id == transacaoCriacaoDto.IdPessoa);

                if (pessoa == null)
                {
                    retorno.Mensagem = "Pessoa não encontrada!";
                    return retorno;
                }

                var transacao = new TabelaTransacoes
                {
                    Descricao = transacaoCriacaoDto.Descricao,
                    Valor = transacaoCriacaoDto.Valor,
                    Tipo = transacaoCriacaoDto.Tipo,
                    IdPessoa = transacaoCriacaoDto.IdPessoa
                };

                context.Transacoes.Add(transacao);
                await context.SaveChangesAsync();

                retorno.Dados = new TransacaoModel
                {
                    Id = transacao.Id,
                    Descricao = transacao.Descricao,
                    Valor = transacao.Valor,
                    Tipo = transacao.Tipo,
                    IdPessoa = transacao.IdPessoa
                };
                retorno.Mensagem = "Transação criada com sucesso!";

                return retorno;
            }
            catch(Exception ex)
            {
                retorno.Mensagem = ex.Message;
                return retorno;
            }
        }

        public async Task<ResponseModel<List<TransacaoModel>>> Listar()
        {
            ResponseModel<List<TransacaoModel>> retorno = new ResponseModel<List<TransacaoModel>>();

            try
            {
                var transacao = await context.Transacoes.Select(t => new TransacaoModel
                {
                    Id = t.Id,
                    Descricao = t.Descricao,
                    Valor = t.Valor,
                    Tipo = t.Tipo,
                    IdPessoa = t.IdPessoa
                }).ToListAsync();

                if (!transacao.Any())
                {
                    retorno.Mensagem = "Nenhum registro encontrado!";
                    return retorno;
                }

                retorno.Dados = transacao;
                retorno.Mensagem = "Transações listadas com sucesso!";

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