using System;
using System.Configuration;


namespace AM.Scheduler.Infrastructure
{
	public class ConfigurationSettings : AM.Scheduler.Infrastructure.IConfigurationSettings
	{
		private readonly string c_databaseConnectionString;
		private readonly string c_messagingBusConnectionString;


		public string DatabaseConnectionString { get { return this.c_databaseConnectionString; } }
		public string MessagingBusConnectionString { get { return this.c_messagingBusConnectionString; } }


		public ConfigurationSettings()
		{
			this.c_databaseConnectionString = ConfigurationManager.AppSettings["databaseConnectionString"];
			this.c_messagingBusConnectionString = ConfigurationManager.AppSettings["messagingBusConnectionString"];
		}
	}
}
