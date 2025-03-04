using Subur.Goods.Delivery.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
