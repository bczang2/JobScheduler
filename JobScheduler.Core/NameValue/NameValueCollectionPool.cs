using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobScheduler.Core.Scheduler
{
    public class NameValueCollectionPool
    {
        public static object _lockObj = new object();
        public static NameValueCollection _nameValue;

        static NameValueCollectionPool()
        {
            if (_nameValue == null)
            {
                lock (_lockObj)
                {
                    if (_nameValue == null)
                    {
                        NameValueCollection properties = new NameValueCollection();

                        // 驱动类型，这里用的mysql，目前支持如下驱动：
                        //Quartz.Impl.AdoJobStore.FirebirdDelegate
                        //Quartz.Impl.AdoJobStore.MySQLDelegate
                        //Quartz.Impl.AdoJobStore.OracleDelegate
                        //Quartz.Impl.AdoJobStore.SQLiteDelegate
                        //Quartz.Impl.AdoJobStore.SqlServerDelegate
                        properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.MySQLDelegate, Quartz";
                        // 数据源名称
                        properties["quartz.jobStore.dataSource"] = "myDS";

                        // 数据库版本
                        /* 数据库版本    MySql.Data.dll版本,二者必须保持一致
                         * MySql-10    1.0.10.1
                         * MySql-109   1.0.9.0
                         * MySql-50    5.0.9.0
                         * MySql-51    5.1.6.0
                         * MySql-65    6.5.4.0
                         * MySql-695   6.9.5.0
                         *             System.Data
                         * SqlServer-20         2.0.0.0
                         * SqlServerCe-351      3.5.1.0
                         * SqlServerCe-352      3.5.1.50
                         * SqlServerCe-400      4.0.0.0
                         * 其他还有OracleODP，Npgsql，SQLite，Firebird，OleDb
                        */
                        properties["quartz.dataSource.myDS.provider"] = "MySql-65";
                        // 连接字符串
                        properties["quartz.dataSource.myDS.connectionString"] = "server=127.0.0.1;database=jobdb;charset=utf8;uid=root;pwd=zangbc";
                        // 事物类型JobStoreTX自动管理 JobStoreCMT应用程序管理
                        properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
                        // 表明前缀
                        properties["quartz.jobStore.tablePrefix"] = "qrtz_";
                        // Quartz Scheduler唯一实例ID，auto：自动生成
                        properties["quartz.scheduler.instanceId"] = "AUTO";
                        // 集群
                        properties["quartz.jobStore.clustered"] = "true";

                        // 设置线程池
                        properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
                        properties["quartz.threadPool.threadCount"] = "5";
                        properties["quartz.threadPool.threadPriority"] = "Normal";

                        // 远程输出配置
                        properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
                        properties["quartz.scheduler.exporter.port"] = "556";
                        properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
                        properties["quartz.scheduler.exporter.channelType"] = "tcp";

                        _nameValue = properties;
                    }
                }
            }
        }

        public static NameValueCollection NameValue
        { 
            get
            {
                return _nameValue;
            }
        }
    }
}
