using System;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Objetivo
    {
        public Guid Codigo { get; }

        public Conta Conta { get; }

        public DateTime DataCriacao { get; }
        public DateTime DataAtualizacao { get; }
        public bool Apagado { get; }
    }
}
