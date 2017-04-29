using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.Scheduler
{
    public class SchedulerPool
    {
        private static ISchedulerFactory schedulerFactory;

        static SchedulerPool()
        {
            if (schedulerFactory == null)
            {
                schedulerFactory = new StdSchedulerFactory(NameValueCollectionPool.NameValue);
            }
        }

        public static IScheduler Scheduler
        {
            get
            {
                IScheduler scheduler = schedulerFactory.GetScheduler();
                if (scheduler != null && !scheduler.IsStarted)
                {
                    scheduler.Start();
                }

                return scheduler;
            }
        }
    }
}
