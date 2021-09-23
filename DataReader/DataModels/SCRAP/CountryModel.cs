using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataModels.SCRAP
{
   public class CountryModel
    {
        public CountryModel(string code, string name, string href)
        {
            Code = code;
            Name = name;
            Href = href;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }


    }
}
