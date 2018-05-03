using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Temple.Core
{
    //public class LoggerService : ILoggerService
    //{
    //    public LoggerService()
    //    {
    //        log4net.Config.XmlConfigurator.Configure();
    //        logger = LogManager.GetLogger(typeof(LoggerService));
    //    }

    //    private readonly ILog logger;

    //    public void Info(string message)
    //    {
    //        logger.Info(message);
    //    }
    //    public void Warn(string message)
    //    {
    //        logger.Warn(message);
    //    }
    //    public void Debug(string message)
    //    {
    //        logger.Debug(message);
    //    }
    //    public void Error(string message)
    //    {
    //        logger.Error(message);
    //    }
    //    public void Error(Exception ex)
    //    {
    //        logger.Error(ex.Message, ex);
    //    }
    //    public void Fatal(string message)
    //    {
    //        logger.Fatal(message);
    //    }
    //    public void Fatal(Exception ex)
    //    {
    //        logger.Fatal(ex.Message, ex);
    //    }
    //}

    public static class Log
    {
        public static ILog Logger = log4net.LogManager.GetLogger("ZH.API");

        static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Info(string msg)
        {
            Logger.Info(msg);
        }

        public static void Info(string format, params object[] args)
        {
            Logger.InfoFormat(format, args);
        }

        public static void Warn(string msg)
        {
            Logger.Warn(msg);
        }

        public static void Warn(string format, params object[] args)
        {
            Logger.WarnFormat(format, args);
        }

        public static void Error(string msg)
        {
            Logger.Error(msg);
        }

        public static void Error(string format, params object[] args)
        {
            Logger.ErrorFormat(format, args);
        }
    }

}