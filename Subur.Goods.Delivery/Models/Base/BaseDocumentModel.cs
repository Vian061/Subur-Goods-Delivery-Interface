using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Base
{
	public abstract class BaseDocumentModel : BaseIdModel
	{
		public BaseDocumentModel()
		{
			DocDate = DocDueDate = DeliveryDate = DateTime.Today;
		}

		[JsonPropertyName("docNum")]
		public string? DocNum { get; set; }

		[JsonPropertyName("docDate")]
		public DateTime DocDate { get; set; }
		[JsonPropertyName("docDueDate")]
		public DateTime DocDueDate { get; set; }
		[JsonPropertyName("deliveryDate")]
		public DateTime DeliveryDate { get; set; }

		[JsonPropertyName("docStatus")]
		public string? DocStatus { get; set; }
		[JsonPropertyName("deliveryStatus")]
		public string? DeliveryStatus { get; set; }

		[JsonPropertyName("remarks")]
		public string? Remarks { get; set; }

		[JsonPropertyName("posDocNum")]
		public string? POSDocNum { get; set; }
	}
}
