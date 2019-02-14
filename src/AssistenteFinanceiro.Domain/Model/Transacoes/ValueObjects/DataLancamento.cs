using AssistenteFinanceiro.Infra.Functional;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.TransacaoValueObjects
{
    public class DataLancamento : ValueObject
    {
        public DateTime Data { get; private set; }

        private DataLancamento() { }
        private DataLancamento(DateTime data) => Data = data;
        
        public static Result<DataLancamento> Criar(DateTime? dataOuNada)
        {
            Maybe<DateTime?> maybeData = dataOuNada;

            return maybeData
                .ToResult("A data de lançamento não deve ser vazia")
                .Ensure(data => data >= DateTime.Today, "A data de lançamento deve ser a data atual ou uma data futura")
                .Map(data => new DataLancamento(data.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Data;
        }
    }
}
