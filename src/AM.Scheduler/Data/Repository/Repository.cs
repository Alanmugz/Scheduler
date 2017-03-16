using log4net;
using MongoDB.Driver;
using System;
using System.Linq;


namespace AM.Scheduler.Data.Repository
{
	public class Repository : AM.Scheduler.Data.Repository.Base, AM.Scheduler.Data.Repository.IRepository
	{
		private readonly IMongoCollection<AM.Scheduler.Data.AggregateRoot.Configuration> c_collection;
		private readonly ILog c_logger;


		public Repository(
			string connectionString,
			ILog logger)
			: base(connectionString)
		{
			var _database = base.ConnectToDatabase();
			this.c_collection = _database.GetCollection<AM.Scheduler.Data.AggregateRoot.Configuration>("configurations");
			this.c_logger = logger;
		}


		public AM.Scheduler.Data.AggregateRoot.Configuration FetchLatestConfiguration()
		{
			var _loggingContext = $"{this.GetType().FullName}.FetchLatestConfiguration";
			this.c_logger.InfoFormat($"{_loggingContext} Commencing");

			var _configuration = this.c_collection.Find(configuration => true).SortByDescending(configuration => configuration.VersionId).FirstOrDefault();
			
			this.c_logger.InfoFormat($"{_loggingContext} Completed");

			return _configuration;
		}
	}
}
