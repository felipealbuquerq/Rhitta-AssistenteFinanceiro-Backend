using AssistenteFinanceiro.Infra.Functional;
using System;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.TransacaoValueObjects
{
    public class DataEfetivacao : ValueObject
    {
        public DateTime? Data { get; private set; }

        private DataEfetivacao() { }
        private DataEfetivacao(DateTime data) => Data = data;


        public static Result<DataEfetivacao> Criar(DateTime dataOuNada)
        {
            Maybe<DateTime?> maybeData = dataOuNada;

            return maybeData
                .ToResult("A data de efetivação não deve ser vazia")
                .Ensure(data => data >= DateTime.Today, "A data de efetivação deve ser a data atual ou uma data futura")
                .Map(data => new DataEfetivacao(data.Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Data;
        }

        public static DataEfetivacao Default => new DataEfetivacao(DateTime.Today);

        public static implicit operator DateTime?(DataEfetivacao data) => data.Data;
    }
}
