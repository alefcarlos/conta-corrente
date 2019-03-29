using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TransferFunds.Application.Services
{
    /// <summary>
    /// Serviço HTTP que consome a api Account
    /// para consulta de informações de contas
    /// </summary>
    public class AccountService
    {
        private readonly HttpClient _client;

        public AccountService(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.BaseAddress = new System.Uri("https://localhost:5000/api/");
        }

        public async Task<bool> ExistsAccountByIDAsync(Guid accountId, CancellationToken cancellationToken)
        {
            return true;
        }

        public async Task<decimal> GetAccountBalanceByIDAsync(Guid accountId, CancellationToken cancellationToken)
        {
            return 20_000;
        }
    }
}
