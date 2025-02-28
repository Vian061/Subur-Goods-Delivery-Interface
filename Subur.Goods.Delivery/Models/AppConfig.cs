namespace Subur.Goods.Delivery.Models
{
	/// <summary>
	///	The configuration model
	/// </summary>
	public class AppConfig
	{
		/// <summary>
		/// The base url of the API
		/// </summary>
		public string Api_Url { get; set; } = "";
		/// <summary>
		/// The base url of the Identity Server 4
		/// </summary>
		public string IS4_Base_Url { get; set; } = "";
		/// <summary>
		/// The client id for the Identity Server 4
		/// </summary>
		public string Client_id { get; set; } = "";
		/// <summary>
		/// The client secret for the Identity Server 4
		/// </summary>
		public string Client_secret { get; set; } = "";
		/// <summary>
		/// The scope for the Identity Server 4
		/// </summary>
		public string Scope { get; set; } = "";
	}

}
