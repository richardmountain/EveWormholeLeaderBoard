using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PodLabs.KmConsole
{
    public static class Log
    {
        public static Logger InitLogger()
        {
            var config = new LoggingConfiguration();
            
            InternalLogger.LogToConsole = true;
            InternalLogger.LogFile = "internal_log.txt";
            InternalLogger.LogWriter = new StringWriter();
            InternalLogger.LogLevel = LogLevel.Trace;

            var consoleTarget = new ColoredConsoleTarget("target1") 
            { 
                Layout = "${ date: format = HH\\:mm\\:ss} : ${ callsite} : ${ level} : ${ message} : ${ exception}"
            };
            config.AddTarget(consoleTarget);

            var fileTarget = new FileTarget("target2")
            {
                FileName = string.Format("logs/{0}", "${date:format=yyy\\MM\\dd}_debug.log"),
                Layout = "${longdate} | ${callsite} | ${level} | ${message} | ${exception}"
            };
            config.AddTarget(fileTarget);

            config.AddRuleForAllLevels(consoleTarget);
            config.AddRuleForAllLevels(fileTarget);

            LogManager.Configuration = config;

            return LogManager.GetCurrentClassLogger();

        }
    }
}
