using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobScheduler.DataAccess.Dao;
using JobScheduler.DataAccess.IDao;

namespace JobScheduler.DataAccess.DbFactory
{
    /// <summary>
    /// Dao 层工厂
    /// </summary>
    public class JobDbScheduleFactory
    {
        public static IJobDetailDao _JobDetailDao = null;

        public static IJobDetailDao JobDetailDao
        {
            get
            {
                if (_JobDetailDao == null)
                {
                    _JobDetailDao = new JobDetailDao();
                }

                return _JobDetailDao;
            }
        }

    }
}
