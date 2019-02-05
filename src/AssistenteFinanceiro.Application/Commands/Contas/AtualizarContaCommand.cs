using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Domain.Model.Contas.ValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using InsurSoft.Backend.Shared.Functional;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistenteFinanceiro.Application.Commands.Contas
{
    public class AtualizarContaCommand : ICommand<Conta>
    {
        public AtualizarContaCommand(Guid codigo, string nome, string icone, string cor)
        {
            Codigo = codigo;
            Nome = nome;
            Icone = icone;
            Cor = cor;
        }

        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public string Cor { get; set; }

        public Result<Conta> Validate()
        {
            var resultNome = NomeConta.Criar(Nome);
            var resultIcone = IconeConta.Criar(Icone, Cor);
            var resultDescricao = DescricaoConta.Criar(null);

            var result = Result.Combine(resultNome, resultIcone, resultDescricao);
            if (result.IsFailure)
                return Result.Fail<Conta>(result.Errors);
            
            return Result.Ok(new Conta(Codigo, resultNome.Value, resultDescricao.Value, resultIcone.Value));
        }
    }
}
