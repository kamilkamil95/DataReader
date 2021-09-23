using DataReader.Engine;
using HtmlAgilityPack;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReaderTests
{
    class WebsiteScraperTests
    {
        
        [Test]
        public void ScrapWebsiteToGetDetailsAboutCountriesAndCities_ReturnsTrue()
        {
            WebsiteScraper websiteScraper = new WebsiteScraper();
            var result = websiteScraper.ScrapWebsiteToGetDetailsAboutCountriesAndCities();
          Assert.That(result, Is.True);
        }
    }
}
