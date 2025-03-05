using Subur.Goods.Delivery.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Subur.Goods.Delivery.Services
{
	public class HttpService : IHttpService
	{
		private readonly HttpClient _httpClient;

		public HttpService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.Timeout = TimeSpan.FromMinutes(5);
		}

		public async Task<T?> GetAsync<T>(string url) where T : class
		{
			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				return JsonSerializer.Deserialize<T>(content);
			}
			else
			{
				throw new Exception(response.RequestMessage?.ToString() ?? response.ReasonPhrase);
			}
		}

		public async Task<HttpResponseMessage> PostAsync<T>(string url, T data) where T : class
		{
			string json = JsonSerializer.Serialize(data);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PostAsync(url, content);

			return response;
		}

		public async Task<HttpResponseMessage> PutAsync<T>(string url, T data) where T : class
		{
			string json = JsonSerializer.Serialize(data);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PutAsync(url, content);

			return response;
		}

		public async Task<HttpResponseMessage> DeleteAsync(string url)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync(url);
			if (response.IsSuccessStatusCode)
			{
				return response;
			}
			else
			{
				throw new Exception(response.RequestMessage?.ToString() ?? response.ReasonPhrase);
			}
		}
	}
}
