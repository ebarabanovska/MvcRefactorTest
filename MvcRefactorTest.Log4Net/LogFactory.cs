using System;
using System.IO;
using System.Reflection;

using log4net;
using log4net.Config;

namespace MvcRefactorTest.Log4Net
{
    public static class LogFactory
    {
        public const string Log4NetConfig = "App.config";

        public static ILog GetLogger()
        {
            var uri =
                new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), Log4NetConfig));
            var configFile = new FileInfo(Path.GetFullPath(uri.LocalPath));
            XmlConfigurator.ConfigureAndWatch(configFile);
            var log = LogManager.GetLogger(typeof(LogFactory));
            return log;
        }
    }
}