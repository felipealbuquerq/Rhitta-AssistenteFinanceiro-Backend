using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Domain.Model.TransacaoValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Core;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Transacao : AggregateRoot
    {
        public Conta Conta { get; }
        public ValorTransacao Valor { get; }
        public TipoTransacao Tipo { get; }

        public bool IsReceita() => Tipo == TipoTransacao.Receita;
        public bool IsDespesa() => !IsReceita();
    }
}
