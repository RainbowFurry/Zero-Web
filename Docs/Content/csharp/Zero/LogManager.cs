using System;
using System.IO;
using System.Reflection;

namespace Zero_Web.Content.csharp.Zero
{
    public class LogManager
    {

        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static protected readonly string logPath = Assembly.GetExecutingAssembly().Location + @"\logs\";
        private static protected readonly string logFile = logPath + DateTime.Now.ToLongDateString() + ".txt";
        private static protected readonly string logFormat = "[" + DateTime.Now.ToLongDateString() + "][" + DateTime.Now.ToLongTimeString() + "][%prio%] ";

        /// <summary>
        /// Create Log4Net Log entrence
        /// </summary>
        /// <param name="logContent"></param>
        public static void addLogEntrence(String logContent)
        {

            log.Info(logContent);
            System.Diagnostics.Debug.WriteLine(logContent);

        }

        /// <summary>
        /// Add a Log Entrence to the Log File
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="logContent"></param>
        public static void addLogEntrence(LogType logType, string logContent)
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            File.AppendAllText(logFile, logFormat.Replace("%prio%", logType.ToString()) + logContent);
            System.Diagnostics.Debug.WriteLine("[LOG]" + logFormat.Replace("%prio%", logType.ToString()) + logContent);

        }

    }

    public enum LogType
    {
        Info,
        Warning,
        Alert,
        Log,
        Success
    }

}