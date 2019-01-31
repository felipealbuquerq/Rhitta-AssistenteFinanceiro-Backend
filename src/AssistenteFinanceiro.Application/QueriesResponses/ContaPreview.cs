using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.QueriesResponses
{
    public class ContaPreview
    {
        public ContaPreview(Guid codigo, string nome, string icone, string cor, decimal saldo)
        {
            Codigo = codigo;
            Nome = nome;
            Icone = icone;
            Cor = cor;
            Saldo = saldo;
        }

        public Guid Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Icone { get; private set; }
        public string Cor { get; private set; }
        public decimal Saldo { get; private set; }
    }
}
