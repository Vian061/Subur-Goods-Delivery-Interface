using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Base
{
	[Serializable]
	public class BaseIdModel
	{
		public BaseIdModel()
		{
		}

		//public string? Id { get; set; }
		[JsonPropertyName("alias")]
		public string? Alias { get; set; }
	}
}
