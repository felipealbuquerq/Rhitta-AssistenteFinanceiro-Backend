using AssistenteFinanceiro.Application.Interfaces.Repositories;
using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.Context;
using Dapper;
using InsurSoft.Backend.Shared.Functional;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistenteFinanceiro.Application.Infra.Repositories
{
    public class ContasRepository : IContasRepository
    {
        private readonly RhittaContext _context;

        public ContasRepository(RhittaContext context)
        {
            _context = context;
        }

        public void AdicionarConta(Conta conta)
        {
            conta.MarcarComoAtualizado();
            _context.Contas.Add(conta);
            _context.SaveChanges();
        }

        public void AtualizarConta(Conta conta)
        {
            conta.MarcarComoAtualizado();
            _context.Entry(conta).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoverConta(Guid id)
        {
            var conta = _context.Contas.AsNoTracking().FirstOrDefault(c => c.Codigo == id);
            if (conta == null)
                return;

            conta.MarcarComoRemovido();
            conta.MarcarComoAtualizado();
            _context.SaveChanges();
        }

        public Maybe<Conta> ObterConta(Guid id)
        {
            return _context.Contas.Find(id);
        }

        public List<ContaPreview> ObterPreviews()
        {
            var query = @"select 
	                        c.codigo,
	                        c.nome,
	                        c.nome_icone as icone,
	                        c.cor_icone as cor,
	                        c.saldo_atual as saldo,
	                        0 as saldoPrevisto,
	                        count(t.codigo) filter (where data_efetivacao is not null) as transacoesRealizadas,
	                        count(t.codigo) filter (where data_efetivacao is null) as transacoesPendentes
                        from contas c 
	                        left join transacoes t on t.codigo_conta = c.codigo
                        where c.apagado = false
                        group by c.codigo;";

            var response = _context.Database.GetDbConnection().Query<ContaPreview>(query).ToList();
            return response;
        }

        public Maybe<ContaPreview> ObterPreview(Guid id)
        {
            return _context.Contas
                .AsNoTracking()
                .Where(c => c.Codigo == id && !c.Apagado)
                .Select(c => new ContaPreview(
                    c.Codigo,
                    c.Nome.Nome,
                    c.Icone.Icone,
                    c.Icone.Cor,
                    c.SaldoAtual,
                    c.SaldoAtual,
                    0,
                    0))
                .FirstOrDefault();
        }
    }
}
