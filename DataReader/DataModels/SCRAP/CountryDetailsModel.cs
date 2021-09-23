using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataModels.SCRAP
{
    class CountryDetailsModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<CityModel> Cities { get; set; }
    }
}
