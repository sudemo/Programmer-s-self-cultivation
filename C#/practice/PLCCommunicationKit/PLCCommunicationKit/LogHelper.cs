using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCCommunicationKit
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

        public static void Infor(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
            else
            {
                logerror.Error("log not ready loginfo.IsInfoEnabled is false");
                Console.WriteLine("log not ready {0}", loginfo.IsInfoEnabled);
            }
        }


        public static void Infor(string info, Exception ex)
        {
            if (loginfo.IsErrorEnabled)
            {
                loginfo.Error(info, ex);
            }
        }
        public static void InfoFormatted(string format, params object[] args)
        {
            loginfo.InfoFormat(format, args);
        }
        public static void DebugFormatted(string format, params object[] args)
        {
            loginfo.DebugFormat(format, args);
        }

        public static void Debug(string message)
        {
            loginfo.Debug(message);
        }
        public static void Debug(string message, Exception ex)
        {
            logerror.Debug(string.Format(message), ex);
        }
        public static void Error(string message)
        {
            logerror.Error(message);
        }
        public static void Error(string message, Exception ex)
        {
            logerror.Error(message, ex);
        }

    }
}
