using AssistenteFinanceiro.Infra.SharedKernel.Core;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Orcamento : BaseEntity
    {
        public Conta Conta { get; }
    }
}
