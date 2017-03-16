using System;
using System.ServiceProcess;


namespace Scheduler
{
	public partial class Scheduler : ServiceBase
	{
		private AM.Scheduler.Application c_app;


		public Scheduler()
		{
			InitializeComponent();
#if DEBUG
			this.OnStart(new string[] { });
#endif
		}


		protected override void OnStart(string[] args)
		{
			this.c_app = new AM.Scheduler.Application();
			this.c_app.StartComponent();
		}


		protected override void OnStop()
		{
			this.c_app.StopComponent();
		}
	}
}
