using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JobScheduler.DataAccess.Const
{
    public class ConfigKey
    {
        public static readonly string JobDbConn_W = ConfigurationManager.ConnectionStrings["MysqlConn"].ConnectionString;
    }
}
