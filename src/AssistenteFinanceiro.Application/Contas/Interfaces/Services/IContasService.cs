using AssistenteFinanceiro.Application.Contas.Commands;
using AssistenteFinanceiro.Application.Contas.Queries;
using AssistenteFinanceiro.Application.Contas.QueriesResponses;
using AssistenteFinanceiro.Infra.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Contas.Interfaces.Services
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
