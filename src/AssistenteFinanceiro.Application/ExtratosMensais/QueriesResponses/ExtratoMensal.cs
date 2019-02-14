using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses
{
    public class ExtratoMensal
    {
        public decimal SaldoAtual { get; private set; }
        public decimal SaldoPrevisto { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        public int TransacoesPendentes => 0;
        public int TransacoesFinalizadas => 0;

        public class Transacao
        {
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
        }
    }
}
