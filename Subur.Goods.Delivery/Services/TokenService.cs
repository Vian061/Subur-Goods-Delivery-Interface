using Duende.IdentityModel.Client;
using Subur.Goods.Delivery.Services.Interfaces;
using System.Net.Http;

namespace Subur.Goods.Delivery.Services
{
	public class TokenService : ITokenService, IDisposable
	{
		private HttpClient _httpClient;

		public TokenService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<string> FetchClientCredentialTokenAsync(string baseUrl, ClientCredentialsTokenRequest clientCredentials)
		{
			_httpClient.BaseAddress = new Uri(baseUrl);

			TokenResponse tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentials);

			return tokenResponse.AccessToken ?? "";
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}
