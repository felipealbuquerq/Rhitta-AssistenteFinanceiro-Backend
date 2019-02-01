using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.Commands.Contas
{
    public class RemoverContaCommand : ICommand<Guid>
    {
        public RemoverContaCommand(Guid codigo)
        {
            Codigo = codigo;
        }

        public RemoverContaCommand()
        {
        }

        public Guid Codigo { get; set; }
        
        public Result<Guid> Validate()
        {
            if (Codigo == null || Codigo == default(Guid))
                return Result.Fail<Guid>("O código não deve ser vazio.");

            return Result.Ok(Codigo);
        }
    }
}
