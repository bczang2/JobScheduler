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
        /// <summary>
        /// 获取appSetting配置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettingConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取数据库链接串信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetDbConnConfigValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
