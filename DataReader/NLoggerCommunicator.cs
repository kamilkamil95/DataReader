using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
  public static class NLoggerCommunicator
    {

        private readonly static ILogger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string msg)
        {
            logger.Info(msg);
        }

         public static void Error(HttpRequestException msg)
        {
            logger.Error(msg);
        }


    }
}
