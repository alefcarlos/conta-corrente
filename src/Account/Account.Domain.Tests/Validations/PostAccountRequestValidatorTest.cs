using Account.Domain.Validations;
using FluentValidation.TestHelper;
using Xunit;

namespace Account.Domain.Tests.Validations
{
    public class PostAccountRequestValidatorTest
    {
        private readonly PostAccountRequestValidator validator;

        public PostAccountRequestValidatorTest()
        {
            validator = new PostAccountRequestValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void WhenCPFIsEmpty_ShouldHaveError(string expectedValue)
        {
            validator.ShouldHaveValidationErrorFor(x => x.CPF, expectedValue);
        }


        [Theory]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        [InlineData("12345678911")]
        public void WhenCPFIsInvalid_ShouldHaveError(string expectedValue)
        {
            validator.ShouldHaveValidationErrorFor(x => x.CPF, expectedValue);
        }

        [Theory]
        [InlineData("41469262894")]
        [InlineData("51507709064")]
        public void WhenCPFIsValid_ShouldSuccess(string expectedValue)
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.CPF, expectedValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void WhenNmaeIsEmpty_ShouldHaveError(string expectedValue)
        {
            validator.ShouldHaveValidationErrorFor(x => x.Name, expectedValue);
        }

        [Theory]
        [InlineData("Alef Carlos")]
        [InlineData("Beltrano da silva")]
        public void WhenNmaeIsEmpty_ShouldSuccess(string expectedValue)
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, expectedValue);
        }
    }
}

