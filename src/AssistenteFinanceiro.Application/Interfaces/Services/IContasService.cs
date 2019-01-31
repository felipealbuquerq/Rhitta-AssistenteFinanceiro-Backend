using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Interfaces.Services
{
    public interface IContasService
    {
        Result CriarConta(ICommand<Conta> command);
        List<ContaPreview> ObterPreviews();
    }
}
