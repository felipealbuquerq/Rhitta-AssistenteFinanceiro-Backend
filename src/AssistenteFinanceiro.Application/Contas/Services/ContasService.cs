using AssistenteFinanceiro.Application.Contas.Commands;
using AssistenteFinanceiro.Application.Contas.Interfaces.Repositories;
using AssistenteFinanceiro.Application.Contas.Interfaces.Services;
using AssistenteFinanceiro.Application.Contas.Queries;
using AssistenteFinanceiro.Application.Contas.QueriesResponses;
using AssistenteFinanceiro.Infra.Functional;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Application.Contas.Services
{
    public class ContasService : IContasService
    {
        private readonly IContasRepository _repository;

        public ContasService(IContasRepository repository)
        {
            _repository = repository;
        }

        public Result CriarConta(CriarContaCommand command)
        {
            var result = command.Validate();

            if (result.IsFailure)
                return result;

            _repository.AdicionarConta(result.Value);

            return Result.Ok();
        }

        public Result AtualizarConta(AtualizarContaCommand command)
        {
            var result = command.Validate();
            if (result.IsFailure)
                return result;

            var contaOrNothing = _repository.ObterConta(command.Codigo);

            if (contaOrNothing.HasNoValue)
                return Result.Fail("Não existe uma conta com o código especificado");

            var conta = contaOrNothing.Value;
            conta.Renomear(result.Value.Nome);
            conta.AtualizarIcone(result.Value.Icone);

            _repository.AtualizarConta(conta);

            return Result.Ok();
        }

        public Result<ContaPreview> ObterPreview(ObterPreviewQuery query)
        {
            var result = query.Validate();

            if (result.IsFailure)
                return Result.Fail<ContaPreview>(result.Errors);

            var queryResult = _repository.ObterPreview(result.Value);

            if (queryResult.HasValue)
                return Result.Ok(queryResult.Value);

            return Result.Ok<ContaPreview>(null);
        }

        public List<ContaPreview> ObterPreviews()
        {
            return _repository.ObterPreviews();
        }

        public Result RemoverConta(RemoverContaCommand command)
        {
            var result = command.Validate();
            if (result.IsFailure)
                return result;

            _repository.RemoverConta(result.Value);

            return Result.Ok();
        }
    }
}
