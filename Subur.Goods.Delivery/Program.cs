// See https://aka.ms/new-console-template for more information

#region File Path

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Subur.Goods.Delivery;
using Subur.Goods.Delivery.Helper;
using Subur.Goods.Delivery.Models.Subur;
using Subur.Goods.Delivery.Services;
using Subur.Goods.Delivery.Services.Interfaces;
using System.Text;
using System.Text.Json;

string environment;

#if DEBUG
environment = "development";
#else
environment = "production";
#endif

environment = "production";
string appConfigPath = $"appconfig.{environment}.json";
Console.WriteLine($"App environtment: {environment}");

#endregion


#region Register Settings
try
{
	//Log.Information("Create Event Bus Host Builder");

	using IHost host = CreateHostBuilder(args).Build();

	var myApp = host.Services.GetService<App>();
	if (myApp == null)
	{
		throw new ApplicationException("App is null");
	}
	await myApp.RunAsync(args);
	await host.RunAsync();
}
finally
{
	//Log.CloseAndFlush();
}


#endregion



IHostBuilder CreateHostBuilder(string[] strings)
{
	return Host.CreateDefaultBuilder()
		.ConfigureServices((_, services) =>
		{
			string appConfigJson = File.ReadAllText(appConfigPath);
			AppConfig? appConfig = JsonSerializer.Deserialize<AppConfig>(appConfigJson);

			if (appConfig == null)
			{
				throw new ApplicationException("AppConfig is null");
			}
			services.AddSingleton(appConfig);
			services.AddSingleton<ITokenService, TokenService>();
			services.AddSingleton<B2CTokenHandler>();
			services.AddSingleton<SuburTokenHandler>();
			services.AddSingleton<LocalSuburTokenHandler>();

			#region Subur Api Client

			services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.SuburClient, client =>
			{
				client.BaseAddress = new Uri(appConfig!.Api_Url);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
			}).AddHttpMessageHandler<SuburTokenHandler>();

			#endregion



			#region Local Subur Api Client

			services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.LocalSuburClient, client =>
			{
				client.BaseAddress = new Uri(appConfig!.Local_Api_Url);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
			}).AddHttpMessageHandler<LocalSuburTokenHandler>();

			#endregion


			#region B2C Service Client

			services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.B2CServiceClient, client =>
			{
				client.BaseAddress = new Uri(appConfig!.Api_Url);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
			}).AddHttpMessageHandler<B2CTokenHandler>();

			#endregion

			#region CarTrack Client

			byte[] authToken = Encoding.ASCII.GetBytes(appConfig.CarTrack_Auth_Key);
			services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.CarTrackHttpClient, client =>
			{
				client.BaseAddress = new Uri(appConfig!.CarTrack_Base_Url);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				client.DefaultRequestHeaders.Add("Basic", Convert.ToBase64String(authToken));
			});

			#endregion

			//#region Error LogClient

			//ClientCredential exceptionClientCredential = exceptionSetting.ClientCredential!;

			//ClientCredentialsTokenRequest clientRequest = new()
			//{
			//	Address = exceptionSetting.ClientCredential?.IdentityUrl,
			//	ClientId = exceptionSetting.ClientCredential?.ClientId!,
			//	ClientSecret = exceptionSetting.ClientCredential?.ClientSecret,
			//	Scope = string.Join(" ", exceptionSetting.ClientCredential?.Scopes!)
			//};

			//services.AddHttpClient(Constant.ExceptionClient, client =>
			//{
			//	client.BaseAddress = new Uri(exceptionClientCredential.BaseAPIUrl!);
			//	client.DefaultRequestHeaders.Clear();
			//	client.DefaultRequestHeaders.Add("Accept", "application/json");

			//}).AddHttpMessageHandler(provider =>
			//{
			//	return new ExceptionClientCredentialHandler(clientRequest);
			//});

			//#endregion

			//services.ConfigureAutomapperService(new MapperConfig());

			services.AddSingleton<App>();
		});
}