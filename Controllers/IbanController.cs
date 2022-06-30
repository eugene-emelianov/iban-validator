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

        /// <summary>
        /// Validates IBAN numbers for more than 60 countries
        /// </summary>
        /// <param name="iban">IBAN</param>
        /// <returns>True if the IBAN is valid and False otherwise</returns>
        [Route("v1/{iban}/validate")]
        [HttpGet]
        public async Task<ActionResult<bool>> Validate(string iban)
        {
            try
            {
                return await _ibanValidator.Validate(iban);
            }
            catch(Exception ex)
            {
                return BadRequest($"IBAN {iban} is invalid. Validation error: {ex.Message}");
            }
        }
    }
}