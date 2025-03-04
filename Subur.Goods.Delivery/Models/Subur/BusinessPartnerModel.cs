using Subur.Goods.Delivery.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery.Models.Subur
{
	public class BusinessPartnerModel : BaseIdModel
	{
		[JsonPropertyName("code")]
		public string? Code { get; set; }
		[JsonPropertyName("customerName")]
		public string? CustomerName { get; set; }
		[JsonPropertyName("balance")]
		public decimal Balance { get; set; }
		[JsonPropertyName("pointReward")]
		public double PointReward { get; set; }
		[JsonPropertyName("pic")]
		public string? PIC { get; set; }
		[JsonPropertyName("phone")]
		public string? Phone { get; set; }
		[JsonPropertyName("fax")]
		public string? Fax { get; set; }
		[JsonPropertyName("mobile")]
		public string? Mobile { get; set; }
		[JsonPropertyName("area")]
		public AreaModel? Area { get; set; }

		[JsonPropertyName("addresses")]
		public ICollection<AddressModel>? Addresses { get; set; }
		[JsonPropertyName("bpGroup")]
		public BusinessPartnerGroupModel? BPGroup { get; set; }

		[JsonPropertyName("creditLimit")]
		public decimal CreditLimit { get; set; }
		[JsonPropertyName("isTaxCount")]
		public bool isTaxCount { get; set; }
		[JsonPropertyName("overallPointReward")]
		public double OverallPointReward { get; set; } = 0;

		[JsonPropertyName("latitude")]
		public decimal Latitude { get; set; }
		[JsonPropertyName("longitude")]
		public decimal Longitude { get; set; }
		[JsonPropertyName("accuracy")]
		public decimal Accuracy { get; set; }
		[JsonPropertyName("birthDate")]
		public DateTime BirthDate { get; set; }
		[JsonPropertyName("transportType")]
		public string? TransportType { get; set; }
	}
}
