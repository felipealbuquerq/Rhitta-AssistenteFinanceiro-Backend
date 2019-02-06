using InsurSoft.Backend.Shared.Functional;
using Microsoft.AspNetCore.Mvc;

namespace AssistenteFinanceiro.Api.Controllers.Base
{
    public class ApiController : Controller
    {
        public ActionResult Result(Result result)
        {
            if (result.IsFailure)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        public ActionResult<T> Result<T>(Result<T> result)
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
