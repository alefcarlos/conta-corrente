namespace Account.Domain.Contracts
{
    public class PostAccountRequest
    {
        /// <summary>
        /// Nome do correntista
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Documento de identificação
        /// </summary>
        public string CPF { get; set; }
    }
}
