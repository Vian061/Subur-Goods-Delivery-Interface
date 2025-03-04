using Duende.IdentityModel.Client;

namespace Subur.Goods.Delivery.Services.Interfaces
{
	public interface ITokenService
	{
		Task<string> FetchClientCredentialTokenAsync(string baseUrl, ClientCredentialsTokenRequest clientCredentials);
		Task<string> FetchSuburTokenAsync(string baseUrl, string username, string password);
	}
}
