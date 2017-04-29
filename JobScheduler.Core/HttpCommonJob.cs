using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobScheduler.Core
{
    /// <summary>
    /// httpcommonJob，jobScheduler通过使用方传递的jsonData中的相关任务参数[如url、param、timeout]来调度执行集体任务
    /// </summary>
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
