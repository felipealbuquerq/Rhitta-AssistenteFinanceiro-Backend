using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses
{
    public class ExtratoMensal
    {
        public ExtratoMensal(decimal saldoAtual, decimal saldoPrevisto, List<Transacao> transacoes)
        {
            SaldoAtual = saldoAtual;
            SaldoPrevisto = saldoPrevisto;
            Transacoes = transacoes;
        }

        public decimal SaldoAtual { get; private set; }
        public decimal SaldoPrevisto { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        public int TransacoesPendentes => Transacoes.Count(t => !t.Efetivada);
        public int TransacoesFinalizadas => Transacoes.Count(t => t.Efetivada);

        public class Transacao
        {
            public Transacao(string descricao, decimal valor, DateTime dataEfetivacao, bool efetivada)
            {
                Descricao = descricao;
                Valor = valor;
                DataEfetivacao = dataEfetivacao;
                Efetivada = efetivada;
            }

            public string Descricao { get; set; }
            public decimal Valor { get; set; }
            public DateTime DataEfetivacao { get; set; }
            public bool Efetivada { get; set; }
        }
    }
}
