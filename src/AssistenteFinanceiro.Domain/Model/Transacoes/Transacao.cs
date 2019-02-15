using AssistenteFinanceiro.Domain.Model.Contas;
using AssistenteFinanceiro.Domain.Model.TransacaoValueObjects;
using AssistenteFinanceiro.Domain.Model.Transacoes.Enums;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;

namespace AssistenteFinanceiro.Domain.Model.Transacoes
{
    public class Transacao : BaseEntity
    {
        protected Transacao() { }

        public Transacao(Guid codigo, Conta conta, ValorTransacao valor, TipoTransacao tipo, DataVencimento dataLancamento, DataEfetivacao dataEfetivacao)
        {
            Codigo = codigo;
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            DataVencimento = dataLancamento;
            DataEfetivacao = dataEfetivacao;
        }

        public Transacao(Conta conta, ValorTransacao valor, TipoTransacao tipo, DataVencimento dataLancamento, DataEfetivacao dataEfetivacao)
        {
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            DataVencimento = dataLancamento;
            DataEfetivacao = dataEfetivacao;
        }
        
        public Conta Conta { get; private set; }
        public ValorTransacao Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        
        public DataVencimento DataVencimento { get; private set; }
        public DataEfetivacao DataEfetivacao { get; private set; }
        public bool Efetivada => DataEfetivacao != null;

        public void Efetivar() => DataEfetivacao = DataEfetivacao.Criar(DateTime.Now).Value;

        public bool IsReceita() => Tipo == TipoTransacao.Receita;
        public bool IsDespesa() => !IsReceita();
        public bool IsAtrasada() => !Efetivada && DataEfetivacao < DateTime.Today;
    }
}
