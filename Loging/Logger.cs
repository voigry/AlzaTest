using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Loging
{
    [TestFixture]
    internal class Logger
    {
        public Logger()
        {

        }

        private static String GetTimeNow()
        {
            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}";
        }

        public static void Log(string message)
        {
            TestContext.Out.WriteLine($"[{GetTimeNow()}] {message}");
        }

        public static void Error(string message)
        {
            TestContext.Error.WriteLine($"[{GetTimeNow()}] {message}");
        }

    }
}
