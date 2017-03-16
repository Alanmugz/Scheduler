using log4net;
using System;


namespace AM.Scheduler.Infrastructure
{
	public class Logger
	{
		private ILog c_logger;


		public ILog LoggerInstance { get { return this.c_logger; } }


		public Logger()
		{
			log4net.Config.XmlConfigurator.Configure();
			this.c_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
		}
	}
}