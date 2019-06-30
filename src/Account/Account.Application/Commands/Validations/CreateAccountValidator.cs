using FluentValidation;
using Framework.Shared;

namespace Account.Application.Commands.Validations
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(r => r.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.");

            RuleFor(r => r.CPF)
                .Must(StringExtensions.IsCpf)
                .WithMessage("CPF não é válido.");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");
        }
    }
}
