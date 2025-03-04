using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class GoodsDeliveryModel : BaseDocumentModel
	{
		public GoodsDeliveryModel()
		{
			Details = [];
		}
		[JsonPropertyName("details")]
		public ICollection<GoodsDeliveryDetailModel> Details { get; set; }

		[JsonPropertyName("vehicle")]
		public VehicleModel? Vehicle { get; set; }
		[JsonPropertyName("driver")]
		public DriverModel? Driver { get; set; }
	}

	public class GoodsDeliveryDetailModel : BaseIdModel
	{
		[JsonPropertyName("lineNo")]
		public int LineNo { get; set; }
		[JsonPropertyName("docNum")]
		public string? DocNum { get; set; }
		[JsonPropertyName("docDate")]
		public DateTime DocDate { get; set; }

		[JsonPropertyName("area")]
		public AreaModel? Area { get; set; }
		[JsonPropertyName("customer")]
		public CustomerModel? Customer { get; set; }

		[JsonPropertyName("latitude")]
		public decimal Latitude { get; set; }
		[JsonPropertyName("longitude")]
		public decimal Longitude { get; set; }
		[JsonPropertyName("accuracy")]
		public decimal Accuracy { get; set; }

		[JsonPropertyName("branch")]
		public string? Branch { get; set; }
		[JsonPropertyName("countItems")]
		public int CountItems { get; set; }

		[JsonPropertyName("lineStatus")]
		public string? LineStatus { get; set; }
		[JsonPropertyName("externalInfo")]
		public string? ExternalInfo { get; set; }
		[JsonPropertyName("remarks")]
		public string? Remarks { get; set; }
	}
}
