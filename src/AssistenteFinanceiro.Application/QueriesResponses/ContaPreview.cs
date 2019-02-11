using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.QueriesResponses
{
    public class ContaPreview
    {
        public ContaPreview(Guid codigo, string nome, string icone, string cor, decimal saldo, decimal saldoPrevisto, int transacoesRealizadas = 0, int transacoesPendentes = 0)
        {
            Codigo = codigo;
            Nome = nome;
            Icone = icone;
            Cor = cor;
            Saldo = saldo;
            SaldoPrevisto = saldoPrevisto;
            TransacoesRealizadas = transacoesRealizadas;
            TransacoesPendentes = transacoesPendentes; 
        }

        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Icone { get; private set; }
        public string Cor { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal SaldoPrevisto { get; private set; }
        public int TransacoesRealizadas { get; private set; }
        public int TransacoesPendentes { get; private set; }
    }
}
