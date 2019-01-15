using InsurSoft.Backend.Shared.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.ContaValueObjects
{
    public class DescricaoConta : ValueObject
    {
        public string Descricao { get; }

        private DescricaoConta(string descricao) => Descricao = descricao;

        public static Result<DescricaoConta> Criar(Maybe<string> descricaoOuNada)
        {
            if (descricaoOuNada.HasNoValue)
                return Result.Ok(new DescricaoConta(""));

            return descricaoOuNada
                .ToResult("A descrição da conta não deve ser vazia")
                .Ensure(descricao => 
                    descricao.Trim().Length <= 255, "A descrição da conta deve ter no máximo 255 caracteres")
                .Map(descricao => new DescricaoConta(descricao));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Descricao;
        }

        public static implicit operator string(DescricaoConta descricao) => descricao.Descricao;
    }
}
