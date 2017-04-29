using JobScheduler.Core.Scheduler;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.JobController
{
    public class CommonJobOpImpl : IJobOperate
    {
        public bool CreateSchedulerJob(string jobName, string jobGroup, string jobData,string jobDesc, string trrigerName, string cron, DateTimeOffset start, DateTimeOffset end)
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                IJobDetail job = JobDetailHelp.CreateJobDetail(jobName, jobGroup, jobData, jobDesc);
                ITrigger cronTrigger = (ICronTrigger)TriggerHelp.CreateTrigger<ICronTrigger>(trrigerName, jobGroup, cron, start, end);

                scheduler.ScheduleJob(job, cronTrigger);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool ResumeAllJob()
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                scheduler.ResumeAll();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                var trigger = new TriggerKey(jobGroup, jobName);
                scheduler.PauseTrigger(trigger);//停止触发器
                scheduler.UnscheduleJob(trigger); //移除触发器
                return scheduler.DeleteJob(JobKey.Create(jobName, jobGroup));
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool PauseAllJob()
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                scheduler.PauseAll();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool PauseJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                scheduler.PauseJob(JobKey.Create(jobName, jobGroup));
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool ResumeJob(string jobName, string jobGroup)
        {
            try
            {
                IScheduler scheduler = SchedulerPool.Scheduler;
                scheduler.ResumeJob(JobKey.Create(jobName, jobGroup));
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
