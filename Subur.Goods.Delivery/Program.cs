// See https://aka.ms/new-console-template for more information

#region File Path

using Microsoft.Extensions.DependencyInjection;
using Subur.Goods.Delivery;
using Subur.Goods.Delivery.Helper;
using Subur.Goods.Delivery.Models;
using Subur.Goods.Delivery.Services;
using Subur.Goods.Delivery.Services.Interfaces;
using System.Text.Json;

string environment;
#if DEBUG
environment = "development";
#else
environment = "production";
#endif

string appConfigPath = $"appconfig.{environment}.json";
Console.WriteLine($"App environtment: {environment}");

#endregion

#region Register Settings

LogHelper.LogMessage($"Application started at {environment} mode.");
try
{
	string appConfigJson = File.ReadAllText(appConfigPath);
	AppConfig? appConfig = JsonSerializer.Deserialize<AppConfig>(appConfigJson);

	var services = new ServiceCollection();
	services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.IS4HttpClient, client =>
	{
		client.BaseAddress = new Uri(appConfig!.IS4_Base_Url);
		client.DefaultRequestHeaders.Clear();
		client.DefaultRequestHeaders.Add("Accept", "application/json");
	}).AddHttpMessageHandler<B2CTokenHandler>();

	var serviceProvider = services.BuildServiceProvider();
	#endregion
}
catch (Exception ex)
{
	LogHelper.LogMessage(ex.Message, true);
	throw;
}
