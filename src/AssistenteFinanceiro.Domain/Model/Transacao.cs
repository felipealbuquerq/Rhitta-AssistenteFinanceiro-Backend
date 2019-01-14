using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Transacao : AggregateRoot
    {
        public Conta Conta { get; }
        public TipoTransacao Tipo { get; }
    }
}
