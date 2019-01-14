using System;
namespace AssistenteFinanceiro.Infra.SharedKernel.Core
{
    public class AggregateRoot
    {
        public Guid Codigo { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime DataAtualizacao { get; protected set; }
        public bool Apagado { get; protected set; }
    }
}
