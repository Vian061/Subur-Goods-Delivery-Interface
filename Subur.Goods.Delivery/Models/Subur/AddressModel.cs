using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class AddressModel : BaseIdModel
	{
		[JsonPropertyName("addressName")]
		public string? AddressName { get; set; }
		[JsonPropertyName("addressLine1")]
		public string? AddressLine1 { get; set; }
		[JsonPropertyName("addressLine2")]
		public string? AddressLine2 { get; set; }
		[JsonPropertyName("addressLine3")]
		public string? AddressLine3 { get; set; }
		[JsonPropertyName("postalCode")]
		public string? PostalCode { get; set; }
		[JsonPropertyName("city")]
		public string? City { get; set; }
		[JsonPropertyName("addressType")]
		public string? AddressType { get; set; }
	}
}
