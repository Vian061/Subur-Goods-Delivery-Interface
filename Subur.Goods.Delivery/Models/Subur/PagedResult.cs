using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{

	public class PagedResult<T>
	{
		[JsonPropertyName("results")]
		public T[] Results { get; set; } = [];
		[JsonPropertyName("currentPage")]
		public int CurrentPage { get; set; }
		[JsonPropertyName("pageCount")]
		public int PageCount { get; set; }
		[JsonPropertyName("pageSize")]
		public int PageSize { get; set; }
		[JsonPropertyName("rowCount")]
		public int RowCount { get; set; }
		[JsonPropertyName("firstRowOnPage")]
		public int FirstRowOnPage { get; set; }
		[JsonPropertyName("lastRowOnPage")]
		public int LastRowOnPage { get; set; }
	}

}
