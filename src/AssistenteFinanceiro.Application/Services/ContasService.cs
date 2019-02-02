using System;
using System.Collections.Generic;
using AssistenteFinanceiro.Application.Interfaces.Repositories;
using AssistenteFinanceiro.Application.Interfaces.Services;
using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
using AssistenteFinanceiro.Infra.SharedKernel.Query;
using InsurSoft.Backend.Shared.Functional;

namespace AssistenteFinanceiro.Application.Services
{
    public class ContasService : IContasService
    {
        private readonly IContasRepository _repository;

        public ContasService(IContasRepository repository)
        {
            _repository = repository;
        }

        public Result CriarConta(ICommand<Conta> command)
        {
            var result = command.Validate();

            if (result.IsFailure)
                return result;

            _repository.AdicionarConta(result.Value);

            return Result.Ok();
        }

        public Result<ContaPreview> ObterPreview(IQuery<Guid> query)
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

        public Result RemoverConta(ICommand<Guid> command)
        {
            var result = command.Validate();
            if (result.IsFailure)
                return result;

            _repository.RemoverConta(result.Value);

            return Result.Ok();
        }
    }
}
