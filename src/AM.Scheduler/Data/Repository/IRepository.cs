using System;


namespace AM.Scheduler.Data.Repository
{
	public interface IRepository
	{
		AM.Scheduler.Data.AggregateRoot.Configuration FetchLatestConfiguration();
	}
}
