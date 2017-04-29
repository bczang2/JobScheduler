using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobScheduler.Core
{
    public class HttpCommonJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            var content = dataMap.GetString("jobData");

            System.IO.File.AppendAllText("e:/data.txt", "key:" + context.JobDetail.Key + "   jsonData:" + content + "    Thread:" + System.Threading.Thread.CurrentThread.Name + "\r\n");
        }
    }
}
