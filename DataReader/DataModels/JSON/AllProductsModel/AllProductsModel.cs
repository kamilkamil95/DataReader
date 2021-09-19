using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataModels.JSON
{
    public class AllProductsModel
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<AllProductsData> data { get; set; }
        public AllProductsSupport support { get; set; }

    }
}
