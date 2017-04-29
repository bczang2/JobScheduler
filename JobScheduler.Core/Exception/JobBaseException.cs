using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace JobScheduler.Core.Exception
{
    public class JobBaseException : SchedulerException
    {
        public JobBaseException(string msg, System.Exception cause)
        {
            
        }
    }
}
