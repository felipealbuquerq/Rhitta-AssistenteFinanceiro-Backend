using AssistenteFinanceiro.Infra.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.Objetivos.ValueObjects
{
    public class ValorObjetivo : ValueObject
    {
        public decimal Valor { get; }

        private ValorObjetivo(decimal valor) => Valor = valor;

        public static Result<ValorObjetivo> Criar(Maybe<decimal> valorOuNada)
        {
            return valorOuNada
                .ToResult("O valor do objetivo não deve ser vazio")
                .Ensure(valor => valor > 0, "O valor do objetivo deve ser maior do que zero")
                .Map(valor => new ValorObjetivo(valor));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }

        public static implicit operator decimal(ValorObjetivo valor) => valor.Valor;
    }
}
