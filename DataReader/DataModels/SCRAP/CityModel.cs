using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataModels.SCRAP
{
    public class CityModel
    {
        public CityModel(string code, string name)
        {
            Code = code;
            Name = name;
        }
        public string Code{ get; set; }
        public string Name { get; set; }
    }
}
