using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.JobController
{
    public interface IJobOperate
    {
        bool CreateSchedulerJob(string jobName, string jobGroup, string jobData, string jobDesc, string trrigerName, string cron, DateTimeOffset start, DateTimeOffset end);
        bool PauseJob(string jobName, string jobGroup);
        bool PauseAllJob();
        bool ResumeJob(string jobName, string jobGroup);
        bool DeleteJob(string jobName, string jobGroup);
        bool ResumeAllJob();
    }
}
