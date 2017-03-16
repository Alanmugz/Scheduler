using System;
using System.ServiceProcess;


namespace Scheduler
{
	static class Program
	{
		static void Main()
		{
#if DEBUG
			new Scheduler();
#else
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new Scheduler()
			};
			ServiceBase.Run(ServicesToRun);
#endif
		}
	}
}
