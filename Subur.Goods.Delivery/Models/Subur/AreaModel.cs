using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;
namespace Subur.Goods.Delivery.Models.Subur
{
	public class AreaModel : BaseIdModel
	{
		[JsonPropertyName("code")]
		public string? Code { get; set; }
		[JsonPropertyName("description")]
		public string? Description { get; set; }
	}
}
