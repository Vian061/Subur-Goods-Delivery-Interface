using Subur.Goods.Delivery.Helper;
using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services;

namespace Subur.Goods.Delivery
{
	internal class App
	{
		private readonly AppConfig _config;
		private readonly HttpService _b2cApiService;
		private readonly HttpService _carTrackApiService;
		private readonly HttpService _suburApiService;

		public App(AppConfig config, IHttpClientFactory httpClientFactory)
		{
			_config = config;
			_b2cApiService = new HttpService(httpClientFactory.CreateClient(Constants.AppConstants.B2CServiceClient));
			_carTrackApiService = new HttpService(httpClientFactory.CreateClient(Constants.AppConstants.CarTrackHttpClient));
			_suburApiService = new HttpService(httpClientFactory.CreateClient(Constants.AppConstants.SuburClient));
		}

		public async Task RunAsync(string[] args)
		{
			try
			{
				Console.WriteLine("Executing Program!");

				int pageNumber = 1;
				int pageSize = 50;
				List<GoodsDeliveryModel> goodsDelivery = [];
				PagedResult<GoodsDeliveryModel>? response = await LoadGoodsDelivery(pageNumber, pageSize);
				if (response != null)
				{
					goodsDelivery.AddRange(response.Results);
				}

				HttpResponseMessage finishResponse = await _suburApiService.PutAsync(Constants.UrlConstans.GoodsDeliveryPaged, goodsDelivery);
				if (!finishResponse.IsSuccessStatusCode)
				{
					LogHelper.LogErrorMessage($"Update Failed: {finishResponse.ReasonPhrase}");
				}
				Console.WriteLine($"Finish Program with status code: {finishResponse.StatusCode}");

				Environment.Exit(0);
			}
			catch (OperationCanceledException ex)
			{
				// Task was canceled; cleanup logic may have already been executed.
				// Optionally log or handle the cancellation.
				//Log.Information($"Operation canceled: {ex.Message}");
				LogHelper.LogErrorMessage($"Operation canceled: {ex.Message}");
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				// Handle exceptions if needed
				//Log.Error($"An error occurred: {ex.Message}");
				//_appLifetime.StopApplication();
				LogHelper.LogErrorMessage($"Operation canceled: {ex.Message}");
				Environment.Exit(0);
			}
		}

		private async Task<PagedResult<GoodsDeliveryModel>?> LoadGoodsDelivery(int pageNumber, int pageSize)
		{
			string pagedGoodsDeliveryUrl = Constants.UrlConstans.GoodsDeliveryPaged
								.Replace("{page_number}", pageNumber.ToString())
								.Replace("{page_size}", pageSize.ToString());
			var response = await _b2cApiService.GetAsync<PagedResult<GoodsDeliveryModel>>(pagedGoodsDeliveryUrl);
			return response;
		}
	}
}
