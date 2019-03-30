using Account.Domain.Contracts;
using FluentValidation;

namespace Account.Domain.Validations
{
    public class PostTransactionRequestValidator : AbstractValidator<PostTransactionRequest>
    {
        public PostTransactionRequestValidator()
        {
            RuleFor(req => req.Value)
                .GreaterThan(0)
                .WithMessage("Valor da transação deve ser maior do que R$ 0,00");

            RuleFor(req => req.Type)
                .IsInEnum()
                .WithMessage("Tipo de transação não permitido.");
        }
    }
}
