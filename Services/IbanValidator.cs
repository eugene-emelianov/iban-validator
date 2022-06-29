using IbanValidator.Interfaces;

namespace IbanValidator.Services
{
    public class IbanValidator : IIbanValidator
    {
        public Task<bool> IsValid(string iban)
        {
            throw new NotImplementedException();
        }
    }
}
