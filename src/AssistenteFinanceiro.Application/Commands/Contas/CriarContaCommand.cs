using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Domain.Model.Contas.ValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;

namespace AssistenteFinanceiro.Application.Commands.Contas
{
    public class CriarContaCommand : ICommand<Conta>
    {
        public CriarContaCommand(string nome, string descricao, string icone, string corIcone, decimal valorInicial)
        {
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
            CorIcone = corIcone;
            ValorInicial = valorInicial;
        }

        public string Nome { get; }
        public string Descricao { get; }
        public string Icone { get; }
        public string CorIcone { get; }
        public decimal ValorInicial { get; }

        public Result<Conta> Validate()
        {
            var nome = NomeConta.Criar(Nome);
            var descricao = DescricaoConta.Criar(Descricao);
            var icone = IconeConta.Criar(Icone, CorIcone);

            var result = Result.Combine(nome, descricao, icone);
            if (result.IsFailure)
                return Result.Fail<Conta>(result.Errors);

            Conta conta = new Conta(
                nome.Value,
                descricao.Value,
                icone.Value,
                ValorInicial
            );

            return Result.Ok(conta);
        }
    }
}
