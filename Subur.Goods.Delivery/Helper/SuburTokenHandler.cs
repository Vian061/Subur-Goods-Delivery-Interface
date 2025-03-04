using Duende.IdentityModel.Client;
using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery.Helper
{
	public class SuburTokenHandler: DelegatingHandler
	{
		private readonly ITokenService _tokenService;
		private readonly AppConfig _appConfig;
		public SuburTokenHandler(ITokenService tokenService, AppConfig appConfig)
		{
			_appConfig = appConfig;
			_tokenService = tokenService;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			string urlRequest = _appConfig.Api_Url + "/pos-api/token";

			string token = await _tokenService.FetchSuburTokenAsync(urlRequest, _appConfig.Username_Subur, _appConfig.Password_Subur);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
