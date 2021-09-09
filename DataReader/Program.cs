using Autofac;
using DataReader.DataAccess;
using DataReader.Engine;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            NLoggerCommunicator.Info("The application has launched...");

            var container = ContainerConfig.Configure();
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
