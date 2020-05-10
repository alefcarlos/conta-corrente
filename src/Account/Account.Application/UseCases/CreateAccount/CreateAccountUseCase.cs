using Flunt.Notifications;
using Flunt.Validations;
using Framework.Shared;
using MediatR;
using PlusUltra.Mediatr;

namespace Account.Application.Commands
{
    public class CreateAccountUseCase : Notifiable, IRequest
    {
        public CreateAccountUseCase(string name, string cpf)
        {
            Name = name;
            CPF = cpf;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(name, nameof(Name), "Nome é obrigatório"));

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(cpf, nameof(CPF), "CPF é obrigatório"));


            AddNotifications(new Contract()
                .IsTrue(StringExtensions.IsCpf(cpf), nameof(CPF), "CPF não é válido."));
        }

        /// <summary>
        /// Nome do correntista
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Documento de identificação
        /// </summary>
        public string CPF { get; }
    }
}
