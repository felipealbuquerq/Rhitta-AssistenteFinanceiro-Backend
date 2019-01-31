using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Interfaces.Repositories
{
    public interface IContasRepository
    {
        void AdicionarConta(Conta conta);
        List<ContaPreview> ObterPreviews();
    }
}
