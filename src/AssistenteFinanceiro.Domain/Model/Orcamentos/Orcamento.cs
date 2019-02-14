using AssistenteFinanceiro.Domain.Model.Contas;
using AssistenteFinanceiro.Infra.SharedKernel.Core;

namespace AssistenteFinanceiro.Domain.Model.Orcamentos
{
    public class Orcamento : BaseEntity
    {
        public Conta Conta { get; }
    }
}
