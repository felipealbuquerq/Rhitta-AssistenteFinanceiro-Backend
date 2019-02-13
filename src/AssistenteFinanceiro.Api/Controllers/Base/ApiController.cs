using InsurSoft.Backend.Shared.Functional;
using Microsoft.AspNetCore.Mvc;

namespace AssistenteFinanceiro.Api.Controllers.Base
{
    public class ApiController : ControllerBase
    {
        protected ActionResult Result(Result result)
        {
            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        protected ActionResult<T> Result<T>(Result<T> result)
        {
            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }

            if (result.Value == null)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }
    }
}
