using AssistenteFinanceiro.Infra.SharedKernel.Query;
using InsurSoft.Backend.Shared.Functional;
using System;

namespace AssistenteFinanceiro.Application.Queries
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
            if (Codigo == null || Codigo == default(Guid))
                return Result.Fail<Guid>("O código da conta não deve ser vazio");

            return Result.Ok(Codigo);
        }
    }
}
