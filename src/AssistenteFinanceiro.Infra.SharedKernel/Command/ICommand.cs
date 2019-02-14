using AssistenteFinanceiro.Infra.Functional;

namespace AssistenteFinanceiro.Infra.SharedKernel.Command
{
    public interface ICommand<T>
    {
        Result<T> Validate();
    }
}
