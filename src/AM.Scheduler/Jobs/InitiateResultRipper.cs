using log4net;
using PMCG.Messaging;
using Quartz;
using System;
using Check = CCS.Common.DBC.Check;


namespace AM.Scheduler.Jobs
{
	public class InitiateResultRipper : IJob
	{
		public void Execute(
			IJobExecutionContext context)
		{
			Check.RequireArgumentNotNull(nameof(context), context);

			var schedulerContext = context.Scheduler.Context;
			var _logger = (ILog)schedulerContext.Get("logger");
			var _messagingBus = (IBus)schedulerContext.Get("messagingBus");
			var _eventIdentifier = (string)schedulerContext.Get("eventIdentifier");

			Check.Ensure(_logger != null, $"Value can't be null - {_logger}");
			Check.Ensure(_messagingBus != null, $"Value can't be null - {_messagingBus}");
			Check.Ensure(_eventIdentifier != null, $"Value can't be null - {_eventIdentifier}");

			var _loggingContext = $"{this.GetType().FullName}.Execute";
			_logger.InfoFormat($"{_loggingContext} Commencing");

			var _event = new AM.Scheduler.Messages.Command.InitiateResultRipper(Guid.NewGuid(), Guid.NewGuid().ToString(), _eventIdentifier);
			_logger.InfoFormat($"{_loggingContext} About to publish event with Id: {_event.Id}, EventIdentifier: {_eventIdentifier}");
			_messagingBus.PublishAsync(_event);
			_logger.InfoFormat($"{_loggingContext} Completed publishing event with Id: {_event.Id}");

			_logger.InfoFormat($"{_loggingContext} Completed");
		}
	}
}
