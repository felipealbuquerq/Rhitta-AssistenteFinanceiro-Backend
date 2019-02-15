using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Infra.Functional;
using AssistenteFinanceiro.Infra.SharedKernel.Query;

namespace AssistenteFinanceiro.Application.ExtratosMensais.Queries
{
    public class ObterExtratoMensalQuery
    {
        public ObterExtratoMensalQuery(int ano, MesDoAno mes)
        {
            Ano = ano;
            Mes = mes;
        }

        public int Ano { get; set; }
        public MesDoAno Mes { get; set; }
    }
}
