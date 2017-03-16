using System;


namespace AM.Scheduler.Infrastructure
{
	public interface IConfigurationSettings
	{
		string DatabaseConnectionString { get; }
		string MessagingBusConnectionString { get; }
	}
}
