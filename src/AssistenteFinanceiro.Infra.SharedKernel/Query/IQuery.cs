using InsurSoft.Backend.Shared.Functional;

namespace AssistenteFinanceiro.Infra.SharedKernel.Query
{
    public interface IQuery<T>
    {
        Result<T> Validate();
    }
}
