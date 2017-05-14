using System;
using System.IO;
using IOUtils;

namespace LogUtils
{
    public class Logger
    {
        private static readonly string LogBaseDirectory = AppDomain.CurrentDomain.BaseDirectory + "Log";
        private static readonly string LogFilePath = LogBaseDirectory + "\\app.log";
        private static readonly string LogSetupFilePath = LogBaseDirectory + "\\logsetup.xml";

        private static Logger _logger;
        private static LogSetup _logSetup;

        private static readonly object LockObject = new object();

        public static Logger GetInstance()
        {
            if (_logger == null)
            {
                lock (LockObject)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();

                        var gxs = new GenericXmlSerializer<LogSetup>();

                        if (!Directory.Exists(LogBaseDirectory))
                        {
                            Directory.CreateDirectory(LogBaseDirectory);
                        }

                        if (!File.Exists(LogSetupFilePath))
                        {
                            var logSetup = new LogSetup
                            {
                                LogLevel = LogLevels.Info
                            };
                            
                            gxs.Serialize(logSetup, LogSetupFilePath);

                            _logSetup = logSetup;
                        }
                        else
                        {
                            _logSetup = gxs.DeSerialize(LogSetupFilePath);
                        }

                        if (!File.Exists(LogFilePath))
                        {
                            using (var sw = new StreamWriter(LogFilePath))
                            {
                                sw.WriteLine(DateTime.Now.ToLongDateString() + " / "  +  DateTime.Now.ToLongTimeString() + " - Log file created.");
                            }
                        }
                    }
                }
            }

            return _logger;
        }

        private Logger() { }

        public void Debug(string message)
        {
            if (_logSetup.LogLevel == LogLevels.Debug)
            {
                WriteLog(message);
            }
        }

        public void Info(string message)
        {
            if (_logSetup.LogLevel == LogLevels.Debug || _logSetup.LogLevel == LogLevels.Info)
            {
                WriteLog(message);
            }
        }

        public void Error(string message)
        {
            if (_logSetup.LogLevel == LogLevels.Debug || _logSetup.LogLevel == LogLevels.Info || _logSetup.LogLevel == LogLevels.Error)
            {
                WriteLog(message);
            }
        }

        private static void WriteLog(string message)
        {
            using (var sw = new StreamWriter(LogFilePath, true))
            {
                sw.WriteLine(DateTime.Now.ToLongTimeString() + " - " + message);
            }
        }
    }
}
