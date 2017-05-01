using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace JobScheduler.Core.Utility
{
    public class LogUtility
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(string cons)
        {
            log.Debug(cons);
        }
        public static void Debug(string cons, System.Exception ex)
        {
            log.Debug(cons, ex);
        }

        public static void Info(string cons)
        {
            log.Info(cons);
        }
        public static void Info(string cons, System.Exception ex)
        {
            log.Info(cons, ex);
        }

        public static void Warn(string cons)
        {
            log.Warn(cons);
        }
        public static void Warn(string cons, System.Exception ex)
        {
            log.Warn(cons, ex);
        }

        public static void Error(string cons)
        {
            log.Error(cons);
        }
        public static void Error(string cons, System.Exception ex)
        {
            log.Info(cons, ex);
        }

        public static void Fatal(string cons)
        {
            log.Fatal(cons);
        }
        public static void Fatal(string cons, System.Exception ex)
        {
            log.Info(cons, ex);
        }
    }
}
