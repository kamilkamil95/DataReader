using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataModels.JSON
{
    public class ProductModel
    {
        //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public Data data { get; set; }
        public Support support { get; set; }
    }
}
