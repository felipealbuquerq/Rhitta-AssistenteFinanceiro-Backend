using AssistenteFinanceiro.Application.Interfaces.Repositories;
using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.Database.Context;
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

        public List<ContaPreview> ObterPreviews()
        {
            var contas = _context.Contas.Select(c => new { c.Codigo, c.Nome.Nome, c.Icone.Icone, c.Icone.Cor, c.SaldoAtual });

            return contas
                .Select(c => new ContaPreview(c.Codigo, c.Nome, c.Icone, c.Cor, c.SaldoAtual))
                .ToList();
        }
    }
}
