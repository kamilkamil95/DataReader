using DataReader.DataAccess;
using DataReader.DataModels.SCRAP;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Engine
{
   public class WebsiteScraper : IWebsiteScraper
    {

        HtmlWeb htmlWeb = new HtmlWeb();



        public bool ScrapWebsiteToGetDetailsAboutCountriesAndCities()
        {
            var CountryDetailsList = new List<CountryDetailsModel>();

             try
              {
            var Countries = CountriesScraper();
            foreach (var country in Countries)
            {
                ConsoleLogger.Info($"Getting cities for {country.Name} ");
                var cities = CityScraper(country).ToList();
                CountryDetailsList.Add(new CountryDetailsModel()
                {
                    Code = country.Code,
                    Name = country.Name,
                    Cities = cities
                });
            }
            return true;

             }
             catch (Exception ex)
            {
                  ConsoleLogger.ErrorHandler(ex);
                  NLoggerCommunicator.Error(ex);
                  return false;                
            }
        }

        private IEnumerable<CityModel> CityScraper(CountryModel country)
        {
           var document = htmlWeb.Load(country.Href);
           var tableRows = document.QuerySelectorAll("body > table:nth-child(3) tr").Skip(1);

            foreach (var city in tableRows)
            {
                var tds = city.QuerySelectorAll("td");
                var code = tds[1].InnerText;
                var name = tds[2].InnerText;
                yield return new CityModel(code, name);
            }
        }

        private IEnumerable<CountryModel> CountriesScraper()
        {
            var document = htmlWeb.Load(Consts.ScraperUrl);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1);

            foreach (var country in tableRows)
            {
                var tds = country.QuerySelectorAll("td");
                var code = tds[0].InnerText;
                var name = tds[1].InnerText;
                var href = tds[1].QuerySelector("a").Attributes["href"].Value;
                yield return new CountryModel(code, name, href);
            }

        }
    }
}
