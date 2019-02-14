using AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Repositories;
using AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Services;
using AssistenteFinanceiro.Application.ExtratosMensais.Queries;
using AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses;
using AssistenteFinanceiro.Infra.Functional;
using System;

namespace AssistenteFinanceiro.Application.ExtratosMensais.Services
{
    public class ExtratoMensalService : IExtratoMensalService
    {
        private readonly IExtratoMensalRepository _repository;

        public ExtratoMensalService(IExtratoMensalRepository repository)
        {
            _repository = repository;
        }

        public Result<ExtratoMensal> ObterExtratoMensal(ObterExtratoMensalQuery query)
        {
            try
            {
                return Result.Ok(_repository.ObterExtratoMensal(query.Ano, (int)query.Mes));
            }
            catch (Exception ex)
            {
                return Result.Fail<ExtratoMensal>("Falha ao obter extrato mensal");
            }
        }
    }
}
