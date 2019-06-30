using Framework.CQRS.Commands;

namespace Account.Application.Commands
{
    public class CreateAccount : ICommand
    {
        public CreateAccount(string name, string cpf)
        {
            Name = name;
            CPF = cpf;
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
