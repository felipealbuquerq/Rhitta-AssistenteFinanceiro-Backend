using AssistenteFinanceiro.Domain.Enums;
using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Transacao
    {
        public Guid Codigo { get; }

        public Conta Conta { get; }
        public TipoTransacao Tipo { get; }

        public DateTime DataCriacao { get; }
        public DateTime DataAtualizacao { get; }
        public bool Apagado { get; }
    }
}
