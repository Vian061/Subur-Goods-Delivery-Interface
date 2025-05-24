using Duende.IdentityModel.Client;
using Newtonsoft.Json;
using Subur.Goods.Delivery.Models;
using Subur.Goods.Delivery.Services.Interfaces;

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
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(baseUrl);

			TokenResponse tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentials);
			if (tokenResponse.AccessToken == null)
			{
				_httpClient.Dispose();

				return string.Empty;
			}

			return tokenResponse.AccessToken;
		}

		public async Task<string> FetchSuburTokenAsync(string baseUrl, string username, string password)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri(baseUrl);
			_httpClient.DefaultRequestHeaders.Clear();
			_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

			var content = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("grant_type", "password"),
				new KeyValuePair<string, string>("username", username),
				new KeyValuePair<string, string>("password", password)
			});

			var result = await _httpClient.PostAsync("Token", content);
			if (!result.IsSuccessStatusCode)
			{
				_httpClient.Dispose();

				return string.Empty;
			}

			string resultContent = await result.Content.ReadAsStringAsync();
			LocalTokenResponse tokenResponse = JsonConvert.DeserializeObject<LocalTokenResponse>(resultContent)!;

			return tokenResponse.AccessToken!;
		}

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}
