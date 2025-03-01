// See https://aka.ms/new-console-template for more information

#region File Path

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

//LogHelper.LogMessage($"Application started at {environment} mode.");
//try
//{
//	string appConfigJson = File.ReadAllText(appConfigPath);
//	AppConfig? appConfig = JsonSerializer.Deserialize<AppConfig>(appConfigJson);

//	var services = new ServiceCollection();
//	services.AddHttpClient<IHttpService, HttpService>(Constants.AppConstants.IS4HttpClient, client =>
//	{
//		client.BaseAddress = new Uri(appConfig!.IS4_Base_Url);
//		client.DefaultRequestHeaders.Clear();
//		client.DefaultRequestHeaders.Add("Accept", "application/json");
//	}).AddHttpMessageHandler<B2CTokenHandler>();

//	var serviceProvider = services.BuildServiceProvider();
//	#endregion
//}
//catch (Exception ex)
//{
//	LogHelper.LogMessage(ex.Message, true);
//	throw;
//}



try
{
	//Log.Information("Create Event Bus Host Builder");

	using IHost host = CreateHostBuilder(args).Build();

	var myApp = host.Services.GetService<App>();
	await myApp!.RunAsync(args);
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
			//services.AddSingleton<ITokenService, TokenService>();
			//services.AddSingleton(new PasswordTokenRequest());


			//#region B2C Service Client

			//ClientCredential clientCredentialSetting = is4Setting.ClientCredential!;

			//services.AddSingleton(is4Setting);
			//services.AddSingleton(clientCredentialSetting!);
			//services.AddScoped<ClientCredentialHandler>();
			//services.AddMemoryCache();

			//services.AddSingleton(new ClientCredentialsTokenRequest()
			//{
			//	Address = is4Setting.ClientCredential?.IdentityUrl,
			//	ClientId = is4Setting.ClientCredential?.ClientId!,
			//	ClientSecret = is4Setting.ClientCredential?.ClientSecret,
			//	Scope = string.Join(" ", is4Setting.ClientCredential?.Scopes!)
			//});

			//services.AddHttpClient(Constant.B2CClient, client =>
			//{
			//	client.BaseAddress = new Uri(b2cSetting.BaseUrl!);
			//	client.DefaultRequestHeaders.Clear();
			//	client.DefaultRequestHeaders.Add("Accept", "application/json");

			//}).AddHttpMessageHandler<ClientCredentialHandler>();

			//#endregion


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


			//#region Car Track Client

			//string AUTH_KEY = carTrackSettings.Username! + ":" + carTrackSettings.Token!;

			//var authToken = Encoding.ASCII.GetBytes(AUTH_KEY);
			//var base64Token = Convert.ToBase64String(authToken);

			//services.AddHttpClient(Constant.CarTrackClient, client =>
			//{
			//	client.BaseAddress = new Uri(carTrackSettings.BaseUrl!);
			//	client.DefaultRequestHeaders.Clear();
			//	client.DefaultRequestHeaders.Add("Accept", "application/json");
			//	client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Token);
			//});
			//services.AddSingleton(carTrackSettings);

			//#endregion


			//#region POS Client

			//services.AddHttpClient(Constant.POSClient, client =>
			//{
			//	client.BaseAddress = new Uri(suburAPISetting.BaseAPIUrl!);
			//	client.DefaultRequestHeaders.Clear();
			//	client.DefaultRequestHeaders.Add("Accept", "application/json");

			//}).AddHttpMessageHandler(provider =>
			//{
			//	var tokenService = provider.GetRequiredService<ITokenService>();
			//	var baseIdentityUrl = configurationSettings.JWTToken!.BaseIdentityUrl;
			//	var username = configurationSettings.JWTToken!.Username;
			//	var password = configurationSettings.JWTToken!.Password;

			//	return new SuburTokenHandler(tokenService, baseIdentityUrl!, username!, password!);
			//});

			//#endregion


			//#region Cloud Client

			//services.AddHttpClient(Constant.CloudClient, client =>
			//{
			//	client.BaseAddress = new Uri(suburAPISetting.CloudAPIUrl!);
			//	client.DefaultRequestHeaders.Clear();
			//	client.DefaultRequestHeaders.Add("Accept", "application/json");

			//}).AddHttpMessageHandler(provider =>
			//{
			//	var tokenService = provider.GetRequiredService<ITokenService>();
			//	var baseIdentityUrl = configurationSettings.CloudJWTToken!.BaseIdentityUrl;
			//	var username = configurationSettings.CloudJWTToken!.Username;
			//	var password = configurationSettings.CloudJWTToken!.Password;

			//	return new SuburTokenHandler(tokenService, baseIdentityUrl!, username!, password!);
			//});

			//#endregion

			//services.ConfigureMassTransitService(configurationSettings.EventBusSetting!, "Subur.POS.CloudToStore.MassTransitConfigurator");

			//services.ConfigureAutomapperService(new MapperConfig());

			//services.AddSingleton(configurationSettings!);
		});
}