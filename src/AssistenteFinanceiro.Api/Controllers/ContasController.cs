using AssistenteFinanceiro.Application.Commands.Contas;
using AssistenteFinanceiro.Application.Interfaces.Services;
using AssistenteFinanceiro.Application.Queries;
using AssistenteFinanceiro.Application.QueriesResponses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AssistenteFinanceiro.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasController : Controller
    {
        private readonly IContasService _service;

        public ContasController(IContasService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ContaPreview>> Get()
        {
            return Ok(_service.ObterPreviews());
        }

        [HttpGet("{codigo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<ContaPreview> Get(Guid codigo)
        {
            var result = _service.ObterPreview(new ObterPreviewQuery(codigo));

            if (result.IsFailure)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult Post([FromBody] CriarContaCommand command)
        {
            var response = _service.CriarConta(command);
            if (response.IsFailure)
                return BadRequest(response.Errors);

            return Ok();
        }

        [HttpDelete("{codigo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult Delete(Guid codigo)
        {
            var response = _service.RemoverConta(new RemoverContaCommand(codigo));
            if (response.IsFailure)
                return BadRequest(response.Errors);

            return Ok();
        }

        [HttpPut("{codigo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult Put([FromBody] AtualizarContaCommand command)
        {
            var response = _service.AtualizarConta(command);
            if (response.IsFailure)
                return BadRequest(response.Errors);

            return Ok();
        }
    }
}
