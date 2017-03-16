using log4net;
using PMCG.Messaging.Client;
using PMCG.Messaging.Client.Configuration;
using Quartz;
using System;
using Check = CCS.Common.DBC.Check;


namespace AM.Scheduler.Infrastructure
{
	public class MessagingBus
	{
		private readonly ILog c_logger;
		private readonly IScheduler c_scheduler;
		private readonly AM.Scheduler.Infrastructure.IConfigurationSettings c_configuration;
		private readonly AM.Scheduler.Infrastructure.QuartzScheduler c_quartzScheduler;


		public IScheduler SchedulerInstance { get { return this.c_scheduler; } }


		public MessagingBus(
			ILog logger,
			AM.Scheduler.Infrastructure.IConfigurationSettings configuration,
			AM.Scheduler.Infrastructure.QuartzScheduler quartzScheduler)
		{
			Check.RequireArgumentNotNull(nameof(logger), logger);
			Check.RequireArgumentNotNull(nameof(configuration), configuration);
			Check.RequireArgumentNotNull(nameof(quartzScheduler), quartzScheduler);

			this.c_logger = logger;
			this.c_configuration = configuration;
			this.c_quartzScheduler = quartzScheduler;
			this.c_scheduler = this.BuildScheduler();
		}


		private IScheduler BuildScheduler()
		{
			var _messagingBusConnectionString = this.c_configuration.MessagingBusConnectionString;
			var _messagingConfigurationBuilder = new BusConfigurationBuilder();
			_messagingConfigurationBuilder.ConnectionUris.Add(_messagingBusConnectionString);

			_messagingConfigurationBuilder.RegisterPublication<AM.Scheduler.Messages.Command.InitiateResultRipper>("resultripper.commands", "resultripper.v1", MessageDeliveryMode.Persistent, message => "resultripper.commands");
			
			var _messagingConfiguration = _messagingConfigurationBuilder.Build();
			Application.Bus = new Bus(_messagingConfiguration);

			return this.c_quartzScheduler.SchedulerInstance();
		}
	}
}
