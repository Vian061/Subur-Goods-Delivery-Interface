namespace Subur.Goods.Delivery.Services.Interfaces
{
	public interface IHttpService
	{
		Task<T?> GetAsync<T>(string url) where T : class;
		Task<HttpResponseMessage> PostAsync<T>(string url, T data) where T : class;
		Task<HttpResponseMessage> PutAsync<T>(string url, T data) where T : class;
		Task<HttpResponseMessage> DeleteAsync(string url);
	}
}
