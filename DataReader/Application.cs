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
        IXmlDocumentReader _xmlReader;
        IWebsiteScraper _websiteScraper;
        string userDecision;

        public Application(IJsonReader jsonReader,IXmlDocumentReader xmlReader,IWebsiteScraper websiteScraper)
        {
            _jsonReader = jsonReader;
            _xmlReader = xmlReader;
            _websiteScraper = websiteScraper;
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
                    _websiteScraper.ScrapWebsiteToGetDetailsAboutCountriesAndCities();
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
