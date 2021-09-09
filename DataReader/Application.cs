using DataReader.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    public class Application : IApplication
    {
        IJsonReader _jsonReader;
        string userDecision;
        public Application(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public void Run()
        {
            ConsoleLogger.UserChoice("To read some Json data chose: 1 ");
            ConsoleLogger.UserChoice("To read some XML data chose: 2 ");
            ConsoleLogger.UserChoice("To read some Text data chose: 3 ");

            userDecision = Console.ReadLine();

            if (userDecision.Equals("1"))
            {
                _jsonReader.ReadJson();

            }
            else
            {
                ConsoleLogger.Warning("Please chose from 1-3.");
                Run();
            }



        }


    }
}
