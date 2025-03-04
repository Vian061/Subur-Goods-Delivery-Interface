using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class BusinessPartnerGroupModel : BaseIdModel
	{
		[JsonPropertyName("code")]
		public string? Code { get; set; }
		[JsonPropertyName("description")]
		public string? Description { get; set; }
		[JsonPropertyName("groupType")]
		public string? GroupType { get; set; }
	}
}
