using Subur.Goods.Delivery.Models.Base;
using System.Text.Json.Serialization;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class DriverModel : BaseIdModel
	{
		[JsonPropertyName("firstName")]
		public string? FirstName { get; set; }
		[JsonPropertyName("lastName")]
		public string? LastName { get; set; }
		[JsonPropertyName("phoneCode")]
		public string? PhoneCode { get; set; }
		[JsonPropertyName("phoneNumber")]
		public string? PhoneNumber { get; set; }
		[JsonPropertyName("email")]
		public string? Email { get; set; }
		[JsonPropertyName("loginName")]
		public string? LoginName { get; set; }
		[JsonPropertyName("loginPassword")]
		public string? LoginPassword { get; set; }
		[JsonPropertyName("registration")]
		public string? Registration { get; set; }

		[JsonPropertyName("isActive")]
		public bool IsActive { get; set; }

		[JsonPropertyName("externalInfo")]
		public string? ExternalInfo { get; set; }
	}
}
