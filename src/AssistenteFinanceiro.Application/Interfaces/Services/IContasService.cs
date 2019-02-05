using AssistenteFinanceiro.Application.Commands.Contas;
using AssistenteFinanceiro.Application.Queries;
using AssistenteFinanceiro.Application.QueriesResponses;
using InsurSoft.Backend.Shared.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Interfaces.Services
{
    public interface IContasService
    {
        Result CriarConta(CriarContaCommand command);
        Result AtualizarConta(AtualizarContaCommand command);
        Result RemoverConta(RemoverContaCommand command);
        List<ContaPreview> ObterPreviews();
        Result<ContaPreview> ObterPreview(ObterPreviewQuery query);
    }
}
