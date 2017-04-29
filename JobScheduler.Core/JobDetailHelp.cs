using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobScheduler.Core
{
    public class JobDetailHelp
    {
        /// <summary>
        /// JobDetailHelp
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="jobGroup"></param>
        /// <param name="jobData"></param>
        /// <param name="jobDesc"></param>
        /// <returns></returns>
        public static IJobDetail CreateJobDetail(string jobName, string jobGroup, string jobData, string jobDesc)
        {
            return JobBuilder.Create<HttpCommonJob>()
                .WithDescription(jobDesc)
                .WithIdentity(jobName, jobGroup)
                .UsingJobData("jobData", jobData)
                .Build();
        }
    }
}
