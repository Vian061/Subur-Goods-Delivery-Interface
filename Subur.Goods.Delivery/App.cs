using Subur.Goods.Delivery.Helper;
using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services;

namespace Subur.Goods.Delivery
{
	internal class App
	{
		private readonly HttpService _b2cApiService;
		private readonly HttpService _suburLocalApiService;

		public App(AppConfig config, IHttpClientFactory httpClientFactory)
		{
			_b2cApiService = new HttpService(httpClientFactory.CreateClient(Constants.AppConstants.B2CServiceClient));
			_suburLocalApiService = new HttpService(httpClientFactory.CreateClient(Constants.AppConstants.LocalSuburClient));
		}

		public async Task RunAsync(string[] args)
		{
			try
			{
				if (args.Count() > 0)
				{
					switch (args[0].ToUpper())
					{
						case "CLOSE_DELIVERY":

							Console.WriteLine("Executing Program -> CLOSE_DELIVERY");

							int pageNumber = 1;
							int pageSize = 50;
							List<GoodsDeliveryModel> goodsDelivery = [];
							PagedResult<GoodsDeliveryModel>? response = await LoadGoodsDelivery(pageNumber, pageSize);
							if (response != null)
							{
								goodsDelivery.AddRange(response.Results);
							}

							if (goodsDelivery.Count == 0)
							{
								Console.WriteLine("No data found!");
								Console.WriteLine("Exiting Application!");
								Environment.Exit(0);
							}
							HttpResponseMessage finishResponse = await _b2cApiService.PutAsync(Constants.UrlConstans.FinishShipment, goodsDelivery);
							if (!finishResponse.IsSuccessStatusCode)
							{
								LogHelper.LogErrorMessage($"Update Failed: {finishResponse.ReasonPhrase}");
							}
							Console.WriteLine($"Finish Program with status code: {finishResponse.StatusCode}");

							break;

						case "CREATE_DELIVERY":

							Console.WriteLine("Executing Program -> CREATE_DELIVERY");
							var goodsDeliveries = await _suburLocalApiService.GetAsync<List<GoodsDeliveryModel>>(Constants.UrlConstans.GetCartrackGoodsDelivery.Replace("{date}", DateTime.Now.ToString("yyyyMMdd")));
							if (goodsDeliveries.Count > 0)
							{
								var retVal = await _b2cApiService.PostObjectAsync(Constants.UrlConstans.CreateGoodsDelivery, goodsDeliveries.ToArray());
								if (!retVal.IsSuccessStatusCode)
								{
									LogHelper.LogErrorMessage($"CREATE_DELIVERY: {retVal.ReasonPhrase}");
								}
								else
								{
									retVal = await _suburLocalApiService.PutAsync(Constants.UrlConstans.UpdateCartrackGoodsDelivery, goodsDeliveries.Select(_ => _.Alias).ToArray());
									if (!retVal.IsSuccessStatusCode)
									{
										LogHelper.LogErrorMessage($"CREATE_DELIVERY: {retVal.ReasonPhrase}");
									}
								}
							}

							break;
					}

					Environment.Exit(0);
				}
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
