using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quartz;
using JobScheduler.Core.Scheduler;
using JobScheduler.Core.JobController;
using JobScheduler.Core.Common;
using JobScheduler.DataAccess.DbFactory;

namespace JobScheduler
{
    public partial class JobScheduleHome : System.Web.UI.Page
    {
        private IJobOperate Job
        {
            get
            {
                return new CommonJobOpImpl();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IScheduler scheduler = SchedulerPool.Scheduler;
            SchedulerMetaData metaInfo = scheduler.GetMetaData();

            scheduleName.InnerText = metaInfo.SchedulerName;
            scheduleRunStatus.InnerText = metaInfo.Started ? "Running" : "Stop";
            scheduleRunSTime.InnerText = metaInfo.RunningSince.Value.ToString("yyyy-MM-dd hh:mm:ss");
            scheduleInstance.InnerText = metaInfo.SchedulerInstanceId;
            threadSize.InnerText = metaInfo.ThreadPoolSize.ToString();
            version.InnerText = metaInfo.Version;
            jobCount.InnerText = JobDbScheduleFactory.JobDetailDao.GetJobCount().ToString();
        }

        protected void AddJob_ServerClick(object sender, EventArgs e)
        {
            string jobNameTx = jobName.Value;
            string jobGroupTx = jobGroup.Value;
            string jobDataTx = jobData.Value;
            string jobCronTx = jobCron.Value;
            string sDate = startdatepicker.Value;
            string eDate = enddatepicker.Value;
            string jobDescTx = jobDesc.Value;
            if (string.IsNullOrWhiteSpace(jobNameTx) || string.IsNullOrWhiteSpace(jobGroupTx) || string.IsNullOrWhiteSpace(jobCronTx))
            {
                MsgAlert("JobName,JobGroup,JobCron必填");
            }
            else if (string.IsNullOrWhiteSpace(sDate) || string.IsNullOrWhiteSpace(eDate))
            {
                MsgAlert("起止日期必填");
            }
            else
            {
                DateTimeOffset start = DateUtility.ConvertStringToDateTimeOffset(sDate);
                DateTimeOffset end = DateUtility.ConvertStringToDateTimeOffset(eDate);
                string triggerName = "trigger_" + Guid.NewGuid();
                if (Job.CreateSchedulerJob(jobNameTx, jobGroupTx, jobDataTx, jobDescTx, triggerName, jobCronTx, start, end))
                {
                    MsgAlert("新增成功!");
                }
                else
                {
                    MsgAlert("新增失败!");
                }
            }
        }

        protected void PauseJob_ServerClick(object sender, EventArgs e)
        {
            string jobNameTx = pauseJobName.Value;
            string jobGroupTx = pauseJobGroup.Value;

            if (string.IsNullOrWhiteSpace(jobNameTx) || string.IsNullOrWhiteSpace(jobGroupTx))
            {
                MsgAlert("JobName,JobGroup必填");
            }
            else
            {
                if (Job.PauseJob(jobNameTx, jobGroupTx))
                {
                    MsgAlert("暂停Job成功!");
                }
                else
                {
                    MsgAlert("暂停Job异常!");
                }
            }
        }

        protected void DeletedJob_ServerClick(object sender, EventArgs e)
        {
            string jobNameTx = delJobName.Value;
            string jobGroupTx = delJobGroup.Value;

            if (string.IsNullOrWhiteSpace(jobNameTx) || string.IsNullOrWhiteSpace(jobGroupTx))
            {
                MsgAlert("JobName,JobGroup必填");
            }
            else
            {
                if (Job.DeleteJob(jobNameTx, jobGroupTx))
                {
                    MsgAlert("删除Job成功!");
                }
                else
                {
                    MsgAlert("删除Job异常!");
                }
            }
        }

        protected void ResumeJob_ServerClick(object sender, EventArgs e)
        {
            string jobNameTx = resumeJobName.Value;
            string jobGroupTx = resumeJobGroup.Value;

            if (string.IsNullOrWhiteSpace(jobNameTx) || string.IsNullOrWhiteSpace(jobGroupTx))
            {
                MsgAlert("JobName,JobGroup必填");
            }
            else
            {
                if (Job.ResumeJob(jobNameTx, jobGroupTx))
                {
                    MsgAlert("恢复Job成功!");
                }
                else
                {
                    MsgAlert("恢复Job异常!");
                }
            }
        }

        protected void MsgAlert(string msg)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "msgAlert('" + msg + "');", true);
        }
    }
}