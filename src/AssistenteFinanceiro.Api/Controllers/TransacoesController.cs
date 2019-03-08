using AssistenteFinanceiro.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AssistenteFinanceiro.Api.Controllers
{
    [ApiController]
    [Route("api/Contas/{codigoConta:guid}/Transacoes")]
    public class TransacoesController : ApiController
    {
        [HttpGet]
        public ActionResult Get(Guid codigoConta)
        {
            return Ok(codigoConta);
        }

        [HttpGet("{codigoTransacao:guid}")]
        public ActionResult Get(Guid codigoConta, Guid codigoTransacao)
        {
            return Ok(new
            {
                codigoConta,
                codigoTransacao
            });
        }

        [HttpPost]
        public ActionResult Post(Guid codigoConta)
        {
            return Ok(codigoConta);
        }
    }
}
