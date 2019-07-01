using FluentValidation.TestHelper;
using System;
using TransferFunds.Domain.Validations;
using Xunit;

namespace TransferFunds.Infra.Validations
{
    public class PostTransferFundsRequestValidatorTest
    {
        private readonly PostTransferFundsRequestValidator validator;
        public PostTransferFundsRequestValidatorTest()
        {
            validator = new PostTransferFundsRequestValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenValueIsLessThan0_ShouldHaveError(decimal expectedValue)
        {
            validator.ShouldHaveValidationErrorFor(x => x.Value, expectedValue);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(10)]
        [InlineData(250)]
        public void WhenValueIsGreaterThan1_ShouldSuccess(decimal expectedValue)
        {
            validator.ShouldNotHaveValidationErrorFor (x => x.Value, expectedValue);
        }
    }
}
