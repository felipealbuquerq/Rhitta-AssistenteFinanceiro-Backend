using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Interfaces.Services
{
    public interface IContasService
    {
        Result CriarConta(ICommand<Conta> command);
        Result RemoverConta(ICommand<Guid> command);
        List<ContaPreview> ObterPreviews();
    }
}
