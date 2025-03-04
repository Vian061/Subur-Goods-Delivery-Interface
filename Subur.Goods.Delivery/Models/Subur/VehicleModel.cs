using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class VehicleModel : BaseIdModel
	{
		[JsonPropertyName("description")]
		public string? Description { get; set; }
		[JsonPropertyName("vehicleNo")]
		public string? VehicleNo { get; set; }
	}
}
