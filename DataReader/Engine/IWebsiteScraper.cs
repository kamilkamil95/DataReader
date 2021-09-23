using DataReader.DataModels.SCRAP;
using System.Collections.Generic;

namespace DataReader.Engine
{
   public interface IWebsiteScraper
    {
        bool ScrapWebsiteToGetDetailsAboutCountriesAndCities();
    }
}