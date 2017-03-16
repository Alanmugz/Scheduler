using log4net;
using Quartz;
using Quartz.Impl;
using System;


namespace AM.Scheduler.Infrastructure
{
	public class QuartzScheduler
	{
		private readonly StdSchedulerFactory c_stdSchedulerFactory;
		private readonly ILog c_logger;
		private readonly AM.Scheduler.Data.Repository.Repository c_repository;


		public QuartzScheduler(
			ILog logger,
			AM.Scheduler.Data.Repository.Repository repository)
		{
			this.c_stdSchedulerFactory = new StdSchedulerFactory();
			this.c_logger = logger;
			this.c_repository = repository; 
		}


		public IScheduler SchedulerInstance()
		{
			var _scheduler = this.c_stdSchedulerFactory.GetScheduler();

			IJobDetail job = JobBuilder.Create<AM.Scheduler.Jobs.InitiateResultRipper>()
				.WithIdentity("resultripperJob", "resultripperGroup")
				.Build();

			var _configuration = this.c_repository.FetchLatestConfiguration();

			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity("resultripperTrigger", "resultripperGroup")
				.WithCronSchedule(_configuration.CronExpression)
				.Build();

			_scheduler.Context.Put("logger", this.c_logger);
			_scheduler.Context.Put("messagingBus", Application.Bus);
			_scheduler.Context.Put("eventIdentifier", _configuration.EventIdentifier);
			_scheduler.ScheduleJob(job, trigger);

			return _scheduler;
		}
	}
}
