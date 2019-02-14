using AssistenteFinanceiro.Infra.Functional;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using System;

namespace AssistenteFinanceiro.Application.Contas.Commands
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
