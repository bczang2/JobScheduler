using JobScheduler.DataAccess.Base;
using JobScheduler.DataAccess.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JobScheduler.DataAccess.Conn;
using MySql.Data.MySqlClient;
using JobScheduler.DataAccess.Utility;
using JobScheduler.DataAccess.Const;

namespace JobScheduler.DataAccess.Dao
{
    public class JobDetailDao : BaseDao, IJobDetailDao
    {
        public int GetJobCount()
        {
            int count = 0;
            using (var conn = DbConnHelp.GetDbConnection<MySqlConnection>(ConfigKey.JobDbConn_W))
            {
                count = conn.Query<int>("select count(1) from qrtz_job_details;").SingleOrDefault<int>();
            }
            return count;
        }
    }
}
