using InsurSoft.Backend.Shared.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Domain.Model.TransacaoValueObjects
{
    public class ValorTransacao : ValueObject
    {
        public decimal Valor { get; }

        private ValorTransacao(decimal valor) => Valor = valor;

        public static Result<ValorTransacao> Criar(Maybe<decimal> valorOuNada)
        {
            return valorOuNada
                .ToResult("O valor da transação não deve ser vazio")
                .Ensure(valor => valor > 0, "O valor da transação deve ser maior do que zero")
                .Map(valor => new ValorTransacao(valor));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }

        public static implicit operator decimal(ValorTransacao valor) => valor.Valor;
    }
}
