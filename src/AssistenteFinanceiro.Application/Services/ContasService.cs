using System.Collections.Generic;
using AssistenteFinanceiro.Application.Interfaces.Repositories;
using AssistenteFinanceiro.Application.Interfaces.Services;
using AssistenteFinanceiro.Application.QueriesResponses;
using AssistenteFinanceiro.Domain.Model;
using AssistenteFinanceiro.Infra.SharedKernel.Command;
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
            var validation = command.Validate();

            if (validation.IsFailure)
                return validation;

            _repository.AdicionarConta(validation.Value);

            return Result.Ok();
        }

        public List<ContaPreview> ObterPreviews()
        {
            return _repository.ObterPreviews();
        }
    }
}
