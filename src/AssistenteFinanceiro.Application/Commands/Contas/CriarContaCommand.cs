using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Domain.Model.Contas.ValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;

namespace AssistenteFinanceiro.Application.Commands.Contas
{
    public class CriarContaCommand : ICommand<Conta>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string CorIcone { get; set; }
        public decimal ValorInicial { get; set; }

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
