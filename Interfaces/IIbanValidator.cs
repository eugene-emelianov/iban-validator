namespace IbanValidator.Interfaces
{
    public interface IIbanValidator
    {
        /// <summary>
        /// Validates IBAN numbers for more than 60 countries
        /// </summary>
        /// <param name="iban">IBAN</param>
        /// <returns>True if the IBAN is valid and False otherwise</returns>
        Task<bool> Validate(string iban);
    }
}
