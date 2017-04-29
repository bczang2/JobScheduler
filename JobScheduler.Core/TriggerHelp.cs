using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobScheduler.Core
{
    public class TriggerHelp
    {
        /// <summary>
        /// TriggerHelp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="triggerName"></param>
        /// <param name="jobGroup"></param>
        /// <param name="cron"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static ITrigger CreateTrigger<T>(string triggerName, string jobGroup, string cron,
            DateTimeOffset start, DateTimeOffset end) where T : ITrigger
        {
            return (T)TriggerBuilder.Create()
                .StartAt(start)
                .EndAt(end)
                .WithIdentity(triggerName, jobGroup)
                .WithCronSchedule(cron).Build();
        }
    }
}
