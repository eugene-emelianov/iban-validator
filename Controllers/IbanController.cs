using Microsoft.AspNetCore.Mvc;

namespace IbanValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbanController : ControllerBase
    {
       private readonly ILogger<IbanController> _logger;

        public IbanController(ILogger<IbanController> logger)
        {
            _logger = logger;
        }

        [Route("v1/{iban}/validate")]
        [HttpGet]
        public ActionResult<bool> Validate(string iban)
        {


            return true;
        }
    }
}