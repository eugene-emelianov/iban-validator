using Xunit;

namespace IbanValidator.Tests
{
    public class IbanValidatorTests
    {
        private Services.IbanValidator _ibanValidator;

        public IbanValidatorTests()
        {
            _ibanValidator = new Services.IbanValidator();
        }

        [Fact]
        public async Task ValidateIban_WhenIbanIsEmpty_ThenThrows()
        {
            // Arrange
            var iban = "";

            // Act
            Task sut() => _ibanValidator.Validate(iban);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(sut);
            Assert.Contains($"IBAN can not be empty", ex.Message);
        }

        [Fact]
        public async Task ValidateIban_WhenIbanHasShortNumberOfDigits_ThenThrows()
        {
            // Arrange
            var iban = "BE1800165492356";

            // Act
            Task sut() => _ibanValidator.Validate(iban);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(sut);
            Assert.Contains($"The expected number of digits for country code", ex.Message);
        }

        [Fact]
        public async Task ValidateIban_WhenIbanExceedsNumberOfDigits_ThenThrows()
        {
            // Arrange
            var iban = "BE180016549235656";

            // Act
            Task sut() => _ibanValidator.Validate(iban);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(sut);
            Assert.Contains($"The expected number of digits for country code", ex.Message);
        }

        [Fact]
        public async Task ValidateIban_WhenModulo97ValidationFails_ThenThrows()
        {
            // Arrange
            var iban = "BE18001654923566";

            // Act
            Task sut() => _ibanValidator.Validate(iban);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(sut);
            Assert.Equal($"Modulo 97 validation filed for iban {iban}", ex.Message);
        }

        [Fact]
        public async Task ValidateIban_WhenUnknowCountryCode_ThenThrows()
        {
            // Arrange
            var iban = "XX82WEST12345698765432";
            
            // Act
            Task sut () => _ibanValidator.Validate(iban);

            // Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(sut);
            Assert.Equal($"Got unknow country code XX", ex.Message);
        }

        [Fact]
        public async Task ValidateIban_WhenValidIbanNumber_ThenIsValidTrue()
        {
            // Arrange
            var iban = "BE18001654923565";

            // Act
            var result = await _ibanValidator.Validate(iban);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ValidateIban_WhenValidForeignIbanNumber_ThenIsValidTrue()
        {
            // Arrange
            var iban = "GB82WEST12345698765432";
      
            // Act
            var result = await _ibanValidator.Validate(iban);

            // Assert
            Assert.True(result);
        }
    }
}