using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JobScheduler.DataAccess.Utility
{
    public class AppConfigUtility
    {
        public static string GetAppSettingConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetDbConnConfigValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
