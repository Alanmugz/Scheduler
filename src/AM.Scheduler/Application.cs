using System;
using log4net;
using PMCG.Messaging;
using PMCG.Messaging.Client;
using Quartz;


namespace AM.Scheduler
{
	public class Application
	{
		private ILog c_logger;
		private IScheduler c_scheduler;
		private AM.Scheduler.Infrastructure.IConfigurationSettings c_configuration;
		private AM.Scheduler.Data.Repository.Repository c_repository;


		public static IBus Bus;


		public Application()
		{
			this.Bootstrapper();
		}


		public void StartComponent()
		{
			var _loggingContext = $"{this.GetType().FullName}.Starting";
			this.c_logger.InfoFormat($"{_loggingContext} Commencing");

			((Bus)Application.Bus).Connect();
			this.c_scheduler.Start();

			this.c_logger.InfoFormat($"{_loggingContext} Completed");
		}


		public void StopComponent()
		{
			var _loggingContext = $"{this.GetType().FullName}.Stopping";
			this.c_logger.InfoFormat($"{_loggingContext} Commencing");

			this.c_scheduler.Shutdown(true);
			((Bus)Application.Bus).Close();

			this.c_logger.InfoFormat($"{_loggingContext} Completed");
		}


		private void Bootstrapper()
		{
			this.c_logger = new AM.Scheduler.Infrastructure.Logger().LoggerInstance;
			this.c_configuration = new AM.Scheduler.Infrastructure.ConfigurationSettings();
			this.c_repository = new AM.Scheduler.Data.Repository.Repository(this.c_configuration.DatabaseConnectionString, this.c_logger);
			var _scheduler = new AM.Scheduler.Infrastructure.QuartzScheduler(this.c_logger, this.c_repository);
			this.c_scheduler = new AM.Scheduler.Infrastructure.MessagingBus(
				this.c_configuration,
				_scheduler).SchedulerInstance;
		}
	}
}
