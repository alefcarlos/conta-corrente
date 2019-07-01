using Account.WebApi.Contracts;
using FluentValidation;
using Framework.Shared;

namespace Account.WebApi.Validations
{
    public class PostAccountRequestValidator : AbstractValidator<PostAccountRequest>
    {
        public PostAccountRequestValidator()
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
