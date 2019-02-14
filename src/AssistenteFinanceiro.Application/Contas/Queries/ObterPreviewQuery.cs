using AssistenteFinanceiro.Infra.Functional;
using AssistenteFinanceiro.Infra.SharedKernel.Query;
using System;

namespace AssistenteFinanceiro.Application.Contas.Queries
{
    public class ObterPreviewQuery : IQuery<Guid>
    {
        public Guid Codigo { get; set; }

        public ObterPreviewQuery(Guid codigo)
        {
            Codigo = codigo;
        }

        public Result<Guid> Validate()
        {
            if (Codigo == default(Guid))
                return Result.Fail<Guid>("O código da conta não deve ser vazio");

            return Result.Ok(Codigo);
        }
    }
}
