using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services.Interfaces;
using System.Net.Http.Headers;

namespace Subur.Goods.Delivery.Helper
{
	public class LocalSuburTokenHandler : DelegatingHandler
	{
		private readonly ITokenService _tokenService;
		private readonly AppConfig _appConfig;
		public LocalSuburTokenHandler(ITokenService tokenService, AppConfig appConfig)
		{
			_appConfig = appConfig;
			_tokenService = tokenService;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			string urlRequest = _appConfig.Local_Api_Url;

			string token = await _tokenService.FetchSuburTokenAsync(urlRequest, _appConfig.Username_Subur, _appConfig.Password_Subur);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
