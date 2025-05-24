namespace Subur.Goods.Delivery.Models.Subur
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
		/// The base url of the CarTrack API
		/// </summary>
		public string CarTrack_Base_Url { get; set; } = "";
		/// <summary>
		/// The auth key for the CarTrack API
		/// </summary>
		public string CarTrack_Auth_Key { get; set; } = "";
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
		/// <summary>
		///	The username for the api subur
		/// </summary>
		public string Username_Subur { get; set; } = "";

		/// <summary>
		/// The password for the api subur
		/// </summary>
		public string Password_Subur { get; set; } = "";

		/// <summary>
		/// Local API url in Store
		/// </summary>
		public string Local_Api_Url { get; set; } = "";
	}

}
