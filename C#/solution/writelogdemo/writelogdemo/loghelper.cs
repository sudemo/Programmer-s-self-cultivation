using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace writelogdemo
{
    public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");


        //public static void SetConfig()
        //{
        //    log4net.Config.XmlConfigurator.Configure();
        //}

        //public static void SetConfig(FileInfo configFile)
        //{
        //    log4net.Config.XmlConfigurator.Configure(configFile);
        //}

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
            else
            {
                loginfo.Info(info);
                Console.WriteLine("log not ready {0}",loginfo.IsInfoEnabled);
            }
        }
        public static void Infor(string message)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(message);
            }
        }
        public static void InfoFormatted(string format, params object[] args)
        {
            loginfo.InfoFormat(format, args);
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, ex);
            }
        }
    }
}
