using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TransferFunds.Application.Settings;
using TransferFunds.Application.ViewModels;

namespace TransferFunds.Application.ExternalServices
{
    /// <summary>
    /// Serviço HTTP que consome a api Account
    /// para consulta de informações de contas
    /// </summary>
    public class AccountService
    {
        private readonly HttpClient _client;

        public AccountService(HttpClient client, IOptions<AccountSettings> settings)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new System.Uri(settings.Value.Uri);
        }

        public async Task<GetAccountResponse> GetAccountByIDAsync(Guid accountId)
        {
            var response = await _client.GetAsync($"/v1/account/{accountId.ToString()}");
            response.EnsureSuccessStatusCode();

            var account = await response.Content.ReadAsAsync<ApiPayload<GetAccountResponse>>();
            return account.Data;
        }

        public async Task<Guid> CreateAccountAsync(PostAccountRequest req)
        {
            var response = await _client.PostAsJsonAsync($"/v1/account", req);
            response.EnsureSuccessStatusCode();

            var accountId = await response.Content.ReadAsAsync<ApiPayload<Guid>>();

            return accountId.Data;
        }

        public async Task<decimal> GetAccountBalanceByIDAsync(Guid accountId)
        {
            var response = await _client.GetAsync($"/v1/account/{accountId.ToString()}/balance");
            response.EnsureSuccessStatusCode();

            var ballance = await response.Content.ReadAsAsync<ApiPayload<decimal>>();

            return ballance.Data;
        }
    }
}
