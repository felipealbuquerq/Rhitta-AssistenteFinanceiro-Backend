using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Objetivo : AggregateRoot
    {
        public Conta Conta { get; }
    }
}
