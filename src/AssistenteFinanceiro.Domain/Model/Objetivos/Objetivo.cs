using AssistenteFinanceiro.Domain.Model.Contas;
using AssistenteFinanceiro.Domain.Model.Objetivos.ValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Core;

namespace AssistenteFinanceiro.Domain.Model.Objetivos
{
    public class Objetivo : BaseEntity
    {
        public Objetivo(Conta conta, ValorObjetivo valor)
        {
            Conta = conta;
            Valor = valor;
        }

        public Conta Conta { get; }
        public ValorObjetivo Valor { get; }

        public bool ObjetivoAtingido() => Conta.SaldoAtual >= Valor;
    }
}
