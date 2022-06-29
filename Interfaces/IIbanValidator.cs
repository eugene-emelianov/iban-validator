namespace IbanValidator.Interfaces
{
    public interface IIbanValidator
    {
        Task<bool> IsValid(string iban);
    }
}
