using IbanValidator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IbanValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbanController : ControllerBase
    {
        private readonly IIbanValidator _ibanValidator;
        private readonly ILogger<IbanController> _logger;

        public IbanController(IIbanValidator ibanValidator, ILogger<IbanController> logger)
        {
            _ibanValidator = ibanValidator;
            _logger = logger;
        }

        [Route("v1/{iban}/validate")]
        [HttpGet]
        public async Task<ActionResult<bool>> Validate(string iban)
        {
            try
            {
                var isValidIban = await _ibanValidator.IsValid(iban);

                return isValidIban ? Ok(isValidIban) : BadRequest($"IBAN {iban} is invalid.");
            }
            catch(Exception ex)
            {
                return BadRequest($"IBAN {iban} is invalid. Validation error: {ex.Message}");
            }
        }
    }
}