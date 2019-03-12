using AssistenteFinanceiro.Api.Controllers.Base;
using AssistenteFinanceiro.Application.ExtratosMensais.Interfaces.Services;
using AssistenteFinanceiro.Application.ExtratosMensais.Queries;
using AssistenteFinanceiro.Application.ExtratosMensais.QueriesResponses;
using AssistenteFinanceiro.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AssistenteFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoMensalController : ApiController
    {
        private readonly IExtratoMensalService _service;

        public ExtratoMensalController(IExtratoMensalService service)
        {
            _service = service;
        }

        [HttpGet("{mes}/{ano:int}")]
        public ActionResult<ExtratoMensal> Get(MesDoAno mes, int ano)
        {
            var query = new ObterExtratoMensalQuery(ano, mes);
            var response = _service.ObterExtratoMensal(query);

            return Result(response);
        }
    }
}