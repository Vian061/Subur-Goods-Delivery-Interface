using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class CustomerModel : BusinessPartnerModel
	{
		[JsonPropertyName("salt")]
		public string? Salt { get; set; }

		[JsonPropertyName("pin")]
		public string? PIN { get; set; }

		[JsonPropertyName("emailAddress")]
		public string? EmailAddress { get; set; }

		[JsonPropertyName("outstandingBills")]
		public int OutstandingBills { get; set; }

		[JsonPropertyName("paymentDays")]
		public string? PaymentDays { get; set; }

		[JsonPropertyName("paymentDueDays")]
		public int PaymentDueDays { get; set; }

		[JsonPropertyName("limitType")]
		public string? LimitType { get; set; }

		[JsonPropertyName("nik")]
		public string? NIK { get; set; }

		[JsonPropertyName("displayMembership")]
		public string? DisplayMembership { get; set; }

		[JsonPropertyName("membershipBarcode")]
		public string? MembershipBarcode { get; set; }

		[JsonPropertyName("deliveryDays")]
		public string? DeliveryDays { get; set; }

		[JsonPropertyName("feesRokok")]
		public decimal FeesRokok { get; set; }
		[JsonPropertyName("feesNonRokok")]
		public decimal FeesNonRokok { get; set; }
		[JsonPropertyName("salesmanNIK")]
		public string? SalesmanNIK { get; set; }
		[JsonPropertyName("externalInfo")]
		public string? ExternalInfo { get; set; }
	}
}
