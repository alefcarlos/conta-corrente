using Account.Domain.Contracts;
using FluentValidation;

namespace Account.Domain.Validations
{
    public class PostAccountRequestValidator : AbstractValidator<PostAccountRequest>
    {
        public PostAccountRequestValidator()
        {
            RuleFor(r => r.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.");

            RuleFor(r => r.CPF)
                .Must(IsCpf)
                .WithMessage("CPF não é válido.");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");
        }

        /// <summary>
        /// Verifica se é um CPF válido.
        /// </summary>
        /// <param name="cpf">string cpf</param>
        /// <returns>bool</returns>
        public static bool IsCpf(string cpf)
        {
            long isCpf;
            if (string.IsNullOrEmpty(cpf) || !long.TryParse(cpf, out isCpf))
            {
                return false;
            }

            if (cpf == "00000000000" || cpf == "11111111111" ||
                cpf == "22222222222" || cpf == "33333333333" ||
                cpf == "44444444444" || cpf == "55555555555" ||
                cpf == "66666666666" || cpf == "77777777777" ||
                cpf == "88888888888" || cpf == "99999999999")
                return false;


            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            var tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto;

            return cpf.EndsWith(digito);
        }
    }
}
