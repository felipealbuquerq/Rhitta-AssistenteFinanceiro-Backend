using AssistenteFinanceiro.Domain.Model.Types;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Conta : AggregateRoot
    {
        public NomeConta Nome { get; }
        public DescricaoConta Descricao { get; }
        public decimal SaldoInicial { get; }
        public decimal SaldoAtual { get; }

        public List<Transacao> Transacoes { get; }
        public List<Orcamento> Orcamentos { get; }
        public List<Objetivo> Objetivos { get; }
    }
}
