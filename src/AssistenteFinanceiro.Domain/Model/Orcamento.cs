using AssistenteFinanceiro.Infra.SharedKernel.Core;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Orcamento : AggregateRoot
    {
        public Conta Conta { get; }
    }
}
