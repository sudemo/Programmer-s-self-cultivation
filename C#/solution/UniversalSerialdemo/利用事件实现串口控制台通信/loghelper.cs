using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalSerial
{
    public class LogHelper
    {
        //public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        //public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("seriallog");
        public static void Info(string message)
        {
            log.Info(message);
        }
        public static void WriteLog(string info)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(info, ex);
            }
        }
    }
}
