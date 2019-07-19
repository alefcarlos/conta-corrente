using Flunt.Notifications;
using Flunt.Validations;
using Framework.CQRS.Commands;
using Framework.Shared;

namespace Account.Application.Commands
{
    public class CreateAccount : Notifiable, ICommand
    {
        public CreateAccount(string name, string cpf)
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
