using InsurSoft.Backend.Shared.Functional;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AssistenteFinanceiro.Domain.Model.Contas.ValueObjects
{
    public class IconeConta : ValueObject
    {
        private const string COR_PATTERN = @"^#[a-zA-Z0-9]{6}$";
        private const string COR_DEFAULT = "#a90329";
        private const string ICONE_DEFAULT = "mdi mdi-cash";

        public string Icone { get; }
        public string Cor { get; }

        private IconeConta(string icone, string cor)
        {
            Icone = icone;
            Cor = cor;
        }

        public static Result<IconeConta> Criar(Maybe<string> iconeOrNothing, Maybe<string> corOrNothing)
        {
            if (iconeOrNothing.HasNoValue)
                iconeOrNothing = COR_DEFAULT;

            if (corOrNothing.HasNoValue)
                corOrNothing = COR_DEFAULT;

            return corOrNothing
                .ToResult()
                .Ensure(cor => Regex.IsMatch(cor, COR_PATTERN), "A cor do ícone deve seguir o padrão hexadecimal")
                .Map(cor => new IconeConta(iconeOrNothing.Value, cor));
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Icone;
            yield return Cor;
        }
    }
}
