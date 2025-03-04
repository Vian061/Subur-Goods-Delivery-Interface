using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery.Models.Base
{
	[Serializable]
	public class BaseIdModel
	{
		public BaseIdModel()
		{
		}

		//public string? Id { get; set; }
		[JsonPropertyName("alias")]
		public string? Alias { get; set; }
	}
}
