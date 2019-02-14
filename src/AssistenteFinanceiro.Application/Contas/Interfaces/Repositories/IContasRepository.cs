using AssistenteFinanceiro.Application.Contas.QueriesResponses;
using AssistenteFinanceiro.Domain.Model.Contas;
using AssistenteFinanceiro.Infra.Functional;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Contas.Interfaces.Repositories
{
    public interface IContasRepository
    {
        void AdicionarConta(Conta conta);
        void AtualizarConta(Conta conta);
        void RemoverConta(Guid id);
        Maybe<Conta> ObterConta(Guid id);
        List<ContaPreview> ObterPreviews();
        Maybe<ContaPreview> ObterPreview(Guid id);
    }
}
