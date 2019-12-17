using System;
using System.IO;
using log4net;
using log4net.Config;

namespace TestAutomation.Logging
{
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");

        public static void InitLogger()
        {
            var separateIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
            var logConfigPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, separateIndex) +
                             "log4net.config";
            var logConfigFile = new FileInfo(logConfigPath);
            XmlConfigurator.Configure(logConfigFile);
        }
    }
}