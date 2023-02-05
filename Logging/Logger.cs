using log4net;
using System;
using System.Globalization;

namespace AlzaTest.Logging
{
    [TestFixture]
    internal class Logger
    {
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Logger()
        {

        }

        private static String GetTimeNow()
        {
            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}";
        }

        public static void Log(string message)
        {
            //TestContext msg. - not in use
            //TestContext.Out.WriteLine($"[{GetTimeNow()}] {message}");
            log.Info(message);
        }

        public static void Error(string message)
        {
            // TestContext msg. - not in use
            //TestContext.Error.WriteLine($"[{GetTimeNow()}] {message}");
            log.Error(message);
        }

    }
}
