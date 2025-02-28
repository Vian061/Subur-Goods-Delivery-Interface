namespace Subur.Goods.Delivery.Helper
{
	/// <summary>
	/// The log helper
	/// </summary>
	public static class LogHelper
	{
		/// <summary>
		/// The log file path
		/// </summary>
		static string logFilePath = "log.txt";
		/// <summary>
		/// Log a message to the log file
		/// </summary>
		/// <param name="message"></param>
		/// <param name="isError"></param>
		public static void LogMessage(string message, bool isError = false)
		{
			string logType = isError ? "ERROR" : "INFO";
			string logEntry = $"{DateTime.Now:dd-MMM-yyyy HH:mm:ss} [{logType}] {message}";

			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine(logEntry);
			}
		}
	}
}
