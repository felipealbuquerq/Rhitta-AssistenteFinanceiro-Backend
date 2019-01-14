using AssistenteFinanceiro.Domain.Model.Types;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Conta
    {
        public Guid Codigo { get; }

        public NomeConta Nome { get; }
        public DescricaoConta Descricao { get; }
        public decimal SaldoInicial { get; }
        public decimal SaldoAtual { get; }

        public List<Transacao> Transacoes { get; }
        public List<Orcamento> Orcamentos { get; }
        public List<Objetivo> Objetivos { get; }

        public DateTime DataCriacao { get; }
        public DateTime DataAtualizacao { get; }
        public bool Apagado { get; }
    }
}
