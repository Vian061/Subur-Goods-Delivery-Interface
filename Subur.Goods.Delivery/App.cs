using Subur.Goods.Delivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subur.Goods.Delivery
{
	internal class App
	{
		private readonly AppConfig _config;

		public App(AppConfig config)
		{
			_config = config;
		}


		public async Task RunAsync(string[] args)
		{
			try
			{

			}
			catch (OperationCanceledException ex)
			{
				// Task was canceled; cleanup logic may have already been executed.
				// Optionally log or handle the cancellation.
				//Log.Information($"Operation canceled: {ex.Message}");
				Environment.Exit(0);
			}
			catch (Exception ex)
			{
				// Handle exceptions if needed
				//Log.Error($"An error occurred: {ex.Message}");
				//_appLifetime.StopApplication();
				Environment.Exit(0);
			}
		}

	}
}
