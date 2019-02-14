using AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Repositories;
using AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses;
using AssistenteFinanceiro.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AssistenteFinanceiro.Application.Infra.Repositories
{
    public class ExtratoMensalRepository : IExtratoMensalRepository
    {
        private readonly RhittaContext _context;

        public ExtratoMensalRepository(RhittaContext context)
        {
            _context = context;
        }

        public ExtratoMensal ObterExtratoMensal(int ano, int mes)
        {
            var transacoesDoMes = _context
                .Transacoes
                .AsNoTracking()
                .Where(c => c.DataLancamento.Data.Month == mes && c.DataLancamento.Data.Year == ano)
                .Select(c => new ExtratoMensal.Transacao(
                    "Descrição pendente",
                    c.Valor,
                    c.DataLancamento.Data,
                    c.Efetivada
                ))
                .ToList();

            var saldoAtual = _context
                .Contas
                .AsNoTracking()
                .Sum(c => c.SaldoAtual);

            var saldoNaoEfetivado = transacoesDoMes
                .Where(t => !t.Efetivada)
                .Sum(t => t.Valor);

            return new ExtratoMensal(saldoAtual, saldoAtual + saldoNaoEfetivado, transacoesDoMes);
        }
    }
}
