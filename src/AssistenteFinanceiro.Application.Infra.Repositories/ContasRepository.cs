using AssistenteFinanceiro.Application.Interfaces.Repositories;
using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.Context;
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
            return _context.Contas
                .AsNoTracking()
                .Include(t => t.Transacoes)
                .Where(c => !c.Apagado)
                .OrderBy(c => c.DataCriacao)
                .Select(c => new ContaPreview(
                    c.Codigo,
                    c.Nome.Nome,
                    c.Icone.Icone,
                    c.Icone.Cor,
                    c.SaldoAtual,
                    c.SaldoAtual,
                    c.TransacoesRealizadas(),
                    c.TransacoesPendentes()))
                 .ToList();
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
