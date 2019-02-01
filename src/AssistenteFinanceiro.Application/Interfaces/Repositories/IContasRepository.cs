using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Interfaces.Repositories
{
    public interface IContasRepository
    {
        void AdicionarConta(Conta conta);
        void RemoverConta(Guid id);
        List<ContaPreview> ObterPreviews();
    }
}
