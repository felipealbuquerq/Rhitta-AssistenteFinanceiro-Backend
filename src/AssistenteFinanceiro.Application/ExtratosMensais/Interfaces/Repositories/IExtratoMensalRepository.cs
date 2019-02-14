using AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses;

namespace AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Repositories
{
    public interface IExtratoMensalRepository
    {
        ExtratoMensal ObterExtratoMensal(int ano, int mes);
    }
}
