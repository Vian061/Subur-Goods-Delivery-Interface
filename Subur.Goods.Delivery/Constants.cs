using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery
{
	public class Constants
	{
		public static class AppConstants {
			public static string SuburClient = "SuburClient";
			public static string B2CServiceClient = "B2CServiceClient";
			public static string CarTrackHttpClient = "CarTrackHttpClient";
		}
		public static class UrlConstans
		{
			#region Subur

			#endregion
			#region B2C Service
			public static string GoodsDeliveryPaged = "deliveryservice/api/v2/GoodsDelivery/Paged/{page_number}/{page_size}";
			#endregion
			#region CarTrack
			public static string CarTrackCompleteJob = "rest/delivery/jobs/{job_id}/complete";
			#endregion
		}
	}
}
