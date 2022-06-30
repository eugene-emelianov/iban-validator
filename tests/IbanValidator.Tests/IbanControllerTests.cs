using Xunit;
using Moq;

namespace IbanValidator.Tests
{
    public class IbanControllerTests
    {
        private Mock<Interfaces.IIbanValidator> _ibanValidator;
        private Controllers.IbanController _ibanController;

        public IbanControllerTests()
        {
            _ibanValidator = new Mock<Interfaces.IIbanValidator>();
            _ibanController = new Controllers.IbanController(_ibanValidator.Object, null);
        }

        [Fact]
        public async Task ValidateIban_WhenIbanIsEmpty_ThenThrows()
        {
            // Arrange
            var iban = "";
            _ibanValidator.Setup(x => x.Validate(iban)).Throws<ArgumentException>();

            // Act
            var sut = await _ibanController.Validate(iban);

            // Assert
            Assert.False(sut.Value);
        }

        [Fact]
        public async Task ValidateIban_When_ThenThrows()
        {
            // Arrange
            var iban = "GB82WEST12345698765432";
            _ibanValidator.Setup(x => x.Validate(iban)).Returns(Task.FromResult(true));

            // Act
            var sut = await _ibanController.Validate(iban);

            // Assert
            Assert.True(sut.Value);
        }

    }
}