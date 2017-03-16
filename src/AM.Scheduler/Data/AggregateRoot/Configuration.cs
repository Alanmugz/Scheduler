using System;


namespace AM.Scheduler.Data.AggregateRoot
{
	public class Configuration : AM.Scheduler.Data.AggregateRoot.IConfiguration
	{
		public string Id { get; set; }
		public int VersionId { get; set; }
		public string EventIdentifier { get; set; }
		public string CronExpression { get; set; }
		public DateTime CreationTimestamp { get; set; }


		public Configuration(
			string id,
			int versionId,
			string eventIdentifier,
			string cronExpression,
			DateTime creationTimestamp)
		{
			this.Id = id;
			this.VersionId = versionId;
			this.EventIdentifier = eventIdentifier;
			this.CronExpression = cronExpression;
			this.CreationTimestamp = creationTimestamp;
		}
	}
}
