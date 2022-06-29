namespace IbanValidator.Interfaces
{
    public interface IIbanValidator
    {
        Task<bool> Validate(string iban);
    }
}
