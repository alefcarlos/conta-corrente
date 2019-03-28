﻿using FluentValidation;
using TransferFunds.Domain.Contracts;

namespace TransferFunds.Domain.Validations
{
    public class PostTransFunderRequestValidator : AbstractValidator<PostTransFunderRequest>
    {
        public PostTransFunderRequestValidator()
        {
            RuleFor(r => r.To)
                .NotEmpty()
                .WithMessage("É obrigatório informar conta de origem.");

            RuleFor(r => r.From)
                .NotEmpty()
                .WithMessage("É obrigatório informar conta de destino.");

            RuleFor(r => r.To)
                .NotEqual(r => r.From)
                .WithMessage("As contas devem ser diferentes!");

            RuleFor(r => r.Value)
                .GreaterThan(0)
                .WithMessage("O valor deve ser maior do que R$ 0,00.");
        }
    }
}
