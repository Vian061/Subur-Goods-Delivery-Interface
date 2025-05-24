namespace Subur.Goods.Delivery
{
	public class Constants
	{
		public static class AppConstants
		{
			public static string SuburClient = "SuburClient";
			public static string B2CServiceClient = "B2CServiceClient";
			public static string CarTrackHttpClient = "CarTrackHttpClient";

			public static string LocalSuburClient = "LocalSuburClient";
		}
		public static class UrlConstans
		{

			#region Subur

			public static string GetCartrackGoodsDelivery = "api/v2/GoodsDeliveries/ProcessToCartrack/{date}";
			public static string UpdateCartrackGoodsDelivery = "api/v2/GoodsDeliveries/ProcessToCartrack";

			#endregion


			#region B2C Service

			public static string GoodsDeliveryPaged = "deliveryservice/api/v2/GoodsDelivery/Paged/{page_number}/{page_size}";
			public static string FinishShipment = "/deliveryservice/api/v2/GoodsDelivery/FinishShipment";

			public static string CreateGoodsDelivery = "deliveryservice/api/v2/GoodsDelivery/FromPOS";

			#endregion


			#region CarTrack

			public static string CarTrackCompleteJob = "rest/delivery/jobs/{job_id}/complete";

			#endregion

		}
	}
}
