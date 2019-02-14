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

        public Transacao(Guid codigo, Conta conta, ValorTransacao valor, TipoTransacao tipo, DataLancamento dataLancamento, DataEfetivacao dataEfetivacao)
        {
            Codigo = codigo;
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            DataLancamento = dataLancamento;
            DataEfetivacao = dataEfetivacao;
        }

        public Transacao(Conta conta, ValorTransacao valor, TipoTransacao tipo, DataLancamento dataLancamento, DataEfetivacao dataEfetivacao)
        {
            Conta = conta;
            Valor = valor;
            Tipo = tipo;
            DataLancamento = dataLancamento;
            DataEfetivacao = dataEfetivacao;
        }
        
        public Conta Conta { get; private set; }
        public ValorTransacao Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        
        public DataLancamento DataLancamento { get; private set; }
        public DataEfetivacao DataEfetivacao { get; private set; }
        public bool Efetivada => DataEfetivacao != null;

        public void Efetivar() => DataLancamento = DataLancamento.Criar(DateTime.Now).Value;

        public bool IsReceita() => Tipo == TipoTransacao.Receita;
        public bool IsDespesa() => !IsReceita();
        public bool IsAtrasada() => !Efetivada && DataEfetivacao < DateTime.Today;
    }
}
