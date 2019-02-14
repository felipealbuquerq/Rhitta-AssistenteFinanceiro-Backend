using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Infra.Functional;
using AssistenteFinanceiro.Infra.SharedKernel.Query;

namespace AssistenteFinanceiro.Application.ExtratosMensais.Queries
{
    public class ObterExtratoMensalQuery
    {
        public int Ano { get; set; }
        public MesDoAno Mes { get; set; }
    }
}
