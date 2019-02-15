using AssistenteFinanceiro.Infra.Functional;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.TransacaoValueObjects
{
    public class DataVencimento : ValueObject
    {
        public DateTime Data { get; private set; }

        private DataVencimento() { }
        private DataVencimento(DateTime data) => Data = data;
        
        public static Result<DataVencimento> Criar(DateTime? dataOuNada)
        {
            Maybe<DateTime?> maybeData = dataOuNada;

            return maybeData
                .ToResult("A data de lançamento não deve ser vazia")
                .Ensure(data => data >= DateTime.Today, "A data de lançamento deve ser a data atual ou uma data futura")
                .Map(data => new DataVencimento(data.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Data;
        }

        public static implicit operator DateTime(DataVencimento data) => data.Data;
        public static implicit operator DateTime?(DataVencimento data) => data.Data;
    }
}
