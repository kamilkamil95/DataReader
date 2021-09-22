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
        XmlDocumentReader _xmlReader;
        string userDecision;

        public Application(IJsonReader jsonReader,XmlDocumentReader xmlReader)
        {
            _jsonReader = jsonReader;
            _xmlReader = xmlReader;
        }


        public void Run()
        {
            ConsoleLogger.UserChoice("To read some Json data chose: 1 ");
            ConsoleLogger.UserChoice("To read some XML data chose: 2 ");
            ConsoleLogger.UserChoice("To Scrap some data chose: 3 ");

            userDecision = Console.ReadLine();

            switch (userDecision)
            {

                case "1":
                    _jsonReader.ReadJson();
                    Run();
                    break;

                case "2":
                    _xmlReader.ReadXml();
                    Run();
                    break;

                case "3":
                    //
                    Run();
                    break;

                default:
                    ConsoleLogger.Warning("Please chose from 1-3.");
                    Run();
                    break;
            }
        }
    }
}
