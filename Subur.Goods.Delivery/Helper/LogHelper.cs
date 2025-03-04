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
		public static void LogMessage(string message)
		{
			string logType = "INFO";
			string logEntry = $"{DateTime.Now:dd-MMM-yyyy HH:mm:ss} [{logType}] {message}";

			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine(logEntry);
			}
		}

		/// <summary>
		/// Log an error message to the log file
		/// </summary>
		/// <param name="message"></param>
		public static void LogErrorMessage(string message)
		{
			string logType = "ERROR";
			string logEntry = $"{DateTime.Now:dd-MMM-yyyy HH:mm:ss} [{logType}] {message}";

			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine(logEntry);
			}
		}
	}
}
