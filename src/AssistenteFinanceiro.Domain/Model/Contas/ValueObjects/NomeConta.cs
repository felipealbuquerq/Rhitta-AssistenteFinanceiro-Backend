using InsurSoft.Backend.Shared.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model.Contas.ValueObjects
{
    public class NomeConta : ValueObject
    {
        public string Nome { get; }

        private NomeConta(string nome) => Nome = nome;

        public static Result<NomeConta> Criar(Maybe<string> nomeOuNada)
        {
            return nomeOuNada
                .ToResult("O nome da conta não deve ser vazio")
                .Ensure(nome => nome.Trim().Length >= 3, "O nome da conta deve ter ao menos 3 caracteres")
                .Ensure(nome => nome.Trim().Length <= 20, "O nome da conta deve ter no máximo 20 caracteres")
                .Map(nome => new NomeConta(nome));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome;
        }

        public static implicit operator string(NomeConta nome) => nome.Nome;
    }
}
