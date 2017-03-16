using System;


namespace AM.Scheduler.Data.AggregateRoot
{
	public interface IConfiguration
	{
		string Id { get; set; }
		int VersionId { get; set; }
		string EventIdentifier { get; set; }
		string CronExpression { get; set; }
		DateTime CreationTimestamp { get; set; }
	}
}
