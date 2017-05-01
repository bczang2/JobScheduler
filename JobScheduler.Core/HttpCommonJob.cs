using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using JobScheduler.Core.HttpProxy;
using JobScheduler.Core.Utility;
using JobScheduler.Core.Common;
using System.Diagnostics;

namespace JobScheduler.Core
{
    /// <summary>
    /// httpcommonJob，jobScheduler通过使用方传递的jsonData中的相关任务参数[如url、postData、timeout]来调度执行具体任务
    /// </summary>
    public class HttpCommonJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                LogUtility.Info(string.Format("job启动执行，jobName: {0}, 执行开始时间: {1}", context.JobDetail.Key,
                    DateUtility.ConvertTimeSpanToDateTime(context.JobRunTime).ToString("yyyy-MM-dd hh:mm:ss")));

                var dataMap = context.JobDetail.JobDataMap;
                var content = dataMap.GetString("jobData");

                HttpRequestItem request = null;
                if (!string.IsNullOrWhiteSpace(content))
                {
                    request = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpRequestItem>(content);
                }
                else
                {
                    request = new HttpRequestItem();
                }
                //发送http请求
                string result = HttpHelp.SendHttpRequest(request);
                //相应处理
                ResponseProcess(result);
            }
            catch (System.Exception ex)
            {
                LogUtility.Error(string.Format("job执行异常，jobName: {0}, 执行开始时间: {1}, 异常信息: {2}", context.JobDetail.Key,
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), ex.Message));
            }

            watch.Stop();
            LogUtility.Info(string.Format("job执行结束，jobName: {0}, 执行结束时间: {1}, 共耗时: {2}", context.JobDetail.Key,
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), watch.Elapsed.TotalMilliseconds));

            //System.IO.File.AppendAllText("e:/data.txt", "key:" + context.JobDetail.Key + "   jsonData:" + content + "    Thread:" + System.Threading.Thread.CurrentThread.Name + "\r\n");
        }

        private void ResponseProcess(string result)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    HttpResponseItem response = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpResponseItem>(result);
                    if (response != null)
                    {
                        switch (response.AckCode)
                        {
                            case ResultAckCodeEnum.Success:
                                LogUtility.Info("job执行结果: 成功");
                                break;
                            case ResultAckCodeEnum.Waring:
                                LogUtility.Warn("job执行结果: 警告; 警告信息:" + response.ResultMsg);
                                break;
                            case ResultAckCodeEnum.Exception:
                            case ResultAckCodeEnum.Error:
                                LogUtility.Error("job执行结果: 失败; 失败信息:" + response.ResultMsg);
                                break;
                        }
                    }
                }
                else
                {
                    LogUtility.Warn("返回结果为空");
                }
            }
            catch (System.Exception ex)
            {
                LogUtility.Error(string.Format("job执行异常, 异常信息: {0}", ex.Message));
            }
        }
    }
}
