using System;
using System.IO;

namespace LogUtils
{
    public class Logger
    {
        public enum LogLevels
        {
            Debug,
            Info,
            Error
        }

        private static LogLevels _logLevel;
        private static string _logFilePath;
        private static bool _isLoggingEnabled;

        private static Logger _logger;

        private static readonly object LockObject = new object();

        public static Logger GetInstance()
        {
            if (_logger == null)
            {
                lock (LockObject)
                {
                    if (_logger == null)
                    {
                        if (string.IsNullOrEmpty(_logFilePath))
                        {
                            throw new Exception("Log file path is not initialized!");
                        }

                        if (_logLevel == null)
                        {
                            throw new Exception("Log level is not initialized!");
                        }

                        _logger = new Logger(_logFilePath, _logLevel);

                        if (!File.Exists(_logFilePath))
                        {
                            using (var sw = new StreamWriter(_logFilePath))
                            {
                                sw.WriteLine(DateTime.Now.ToLongDateString() + " / " + DateTime.Now.ToLongTimeString() +
                                             " - Log file created.");
                            }
                        }
                    }
                }
            }

            return _logger;
        }

        private Logger(string logFilePath, LogLevels logLevel)
        {
            _logFilePath = logFilePath;
            _logLevel = logLevel;
        }

        public static void Initialize(string logFilePath, LogLevels logLevel, bool isLoggingEnabled)
        {
            _logFilePath = logFilePath;
            _logLevel = logLevel;
            _isLoggingEnabled = isLoggingEnabled;
        }

        public void Debug(string message)
        {
            if (_logLevel == LogLevels.Debug)
            {
                WriteLog(message);
            }
        }

        public void Info(string message)
        {
            if (_logLevel == LogLevels.Debug || _logLevel == LogLevels.Info)
            {
                WriteLog(message);
            }
        }

        public void Error(string message)
        {
            if (_logLevel == LogLevels.Debug || _logLevel == LogLevels.Info || _logLevel == LogLevels.Error)
            {
                WriteLog(message);
            }
        }

        private static void WriteLog(string message)
        {
            if (_isLoggingEnabled)
            {
                using (var sw = new StreamWriter(_logFilePath, true))
                {
                    sw.WriteLine(DateTime.Now.ToLongTimeString() + " - " + message);
                }
            }
        }
    }
}
