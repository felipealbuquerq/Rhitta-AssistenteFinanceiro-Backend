using AssistenteFinanceiro.Domain.Model.Types;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Conta
    {
        public Guid Codigo { get; }

        public NomeConta Nome { get; }
        public DescricaoConta Descricao { get; }
        public decimal SaldoInicial { get; }
        public decimal SaldoAtual { get; }

        public DateTime DataCriacao { get; }
        public DateTime DataAtualizacao { get; }
        public bool Apagada { get; }
    }
}
