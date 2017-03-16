using MongoDB.Driver;
using System;


namespace AM.Scheduler.Data.Repository
{
	public class Base
	{
		private readonly string c_connectionString;

		public Base(
			string connectionString)
		{
			this.c_connectionString = connectionString;
		}


		public IMongoDatabase ConnectToDatabase()
		{
			var _connectionString = this.c_connectionString.Split('*')[0];
			var _database = this.c_connectionString.Split('*')[1];
			var client = new MongoClient(_connectionString);
			return client.GetDatabase(_database);
		}
	}
}
