using AssistenteFinanceiro.Application.Commands.Contas;
using AssistenteFinanceiro.Application.Interfaces.Services;
using AssistenteFinanceiro.Application.QueriesResponses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace AssistenteFinanceiro.Api.Controllers
{
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
        
        [HttpPost]
        public ActionResult Post([FromBody] CriarContaCommand command)
        {
            var response = _service.CriarConta(command);
            if (response.IsFailure)
                return BadRequest(response.Errors);

            return Created(string.Empty, null);
        }
    }
}
