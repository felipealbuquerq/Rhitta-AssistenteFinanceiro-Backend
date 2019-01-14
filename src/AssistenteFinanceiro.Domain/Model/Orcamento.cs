using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Orcamento : AggregateRoot
    {
        public Conta Conta { get; }
    }
}
