using Duende.IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery.Services.Interfaces
{
	public interface ITokenService
	{
		Task<string> FetchClientCredentialTokenAsync(string baseUrl, ClientCredentialsTokenRequest clientCredentials);
		Task<string> FetchSuburTokenAsync(string baseUrl, string username, string password);
	}
}
