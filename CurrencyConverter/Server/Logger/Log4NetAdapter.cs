﻿using log4net;

namespace Server
{
    class Log4NetAdapter : ILogger
    {
        private static readonly ILog _log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogInfo(string message) => _log.Warn(message);
    }
}
