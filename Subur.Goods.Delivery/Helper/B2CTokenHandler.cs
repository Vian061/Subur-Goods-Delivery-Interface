using Duende.IdentityModel.Client;
using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services.Interfaces;
using System.Net.Http.Headers;

namespace Subur.Goods.Delivery.Helper
{
	public class B2CTokenHandler : DelegatingHandler
	{
		private readonly ITokenService _tokenService;
		private readonly AppConfig _appConfig;
		public B2CTokenHandler(ITokenService tokenService, AppConfig appConfig)
		{
			_appConfig = appConfig;
			_tokenService = tokenService;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			ClientCredentialsTokenRequest clientCredentialsToken = new ClientCredentialsTokenRequest
			{
				Address = _appConfig.IS4_Base_Url + "/connect/token",
				ClientId = _appConfig.Client_id,
				ClientSecret = _appConfig.Client_secret,
				Scope = _appConfig.Scope
			};

			string token = await _tokenService.FetchClientCredentialTokenAsync(_appConfig.IS4_Base_Url, clientCredentialsToken);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
