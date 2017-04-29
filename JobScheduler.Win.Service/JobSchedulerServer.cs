using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using JobScheduler.Core.Scheduler;
using JobScheduler.Win.Service.Log;

namespace JobScheduler.Win.Service
{
    public class JobSchedulerServer
    {
        private readonly IScheduler scheduler;

        public JobSchedulerServer()
        {
            scheduler = SchedulerPool.Scheduler;
        }

        /// <summary>
        /// 服务启动
        /// </summary>
        public void Start()
        {
            LogUtility.Info("Start...");
            scheduler.Start();
        }
        /// <summary>
        /// 服务停止
        /// </summary>
        public void Stop()
        {
            LogUtility.Info("Stop...");
            scheduler.Shutdown(false);
        }
        /// <summary>
        /// 继续服务
        /// </summary>
        public void Continue()
        {
            LogUtility.Info("Continue...");
            scheduler.ResumeAll();
        }
        /// <summary>
        /// 服务暂停
        /// </summary>
        public void Pause()
        {
            LogUtility.Info("Pause...");
            scheduler.PauseAll();
        }
    }
}
