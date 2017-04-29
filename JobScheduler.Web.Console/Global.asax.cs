using JobScheduler.Core.Scheduler;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace JobScheduler
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IScheduler sched = null;
            try
            {
                sched = SchedulerPool.Scheduler;

                if (sched != null && !sched.IsStarted)
                {
                    sched.Start();
                }
            }
            catch (Exception)
            {
                if (sched != null)
                {
                    sched.Shutdown();
                }
            }
        }
    }
}