using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Domain.Model.TransacaoValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Transacao : AggregateRoot
    {
        public Transacao(Conta conta, ValorTransacao valor, TipoTransacao tipo, DataEfetivacao dataEfetivacao)
        {
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            DataEfetivacao = dataEfetivacao;
        }

        public Transacao(Conta conta, ValorTransacao valor, TipoTransacao tipo) 
            : this(conta, valor, tipo, DataEfetivacao.Default)
        {

        }

        public Conta Conta { get; }
        public ValorTransacao Valor { get; }
        public TipoTransacao Tipo { get; }
        
        public DataEfetivacao DataEfetivacao { get; private set; }
        public bool Efetivada { get; private set; }
        
        public bool IsReceita() => Tipo == TipoTransacao.Receita;
        public bool IsDespesa() => !IsReceita();
        public bool IsAtrasada() => !Efetivada && DataEfetivacao < DateTime.Today;
    }
}
