using System;
using Check = CCS.Common.DBC.Check;


namespace AM.Scheduler.Messages.Command
{
	public class InitiateResultRipper : PMCG.Messaging.Event
	{
		public readonly string EventId;
	

		public InitiateResultRipper(
			Guid id,
			string correlationId,
			string eventId)
			: base(id, correlationId)
		{
			Check.RequireArgumentNotEmpty(nameof(eventId), $"Value can't be null - {EventId}");

			this.EventId = eventId;
		}
	}
}