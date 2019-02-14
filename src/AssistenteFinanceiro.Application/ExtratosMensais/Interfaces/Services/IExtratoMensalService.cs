using AssistenteFinanceiro.Application.ExtratosMensais.Queries;
using AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses;
using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Infra.Functional;

namespace AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Services
{
    public interface IExtratoMensalService
    {
        Result<ExtratoMensal> ObterExtratoMensal(ObterExtratoMensalQuery query);
    }
}
