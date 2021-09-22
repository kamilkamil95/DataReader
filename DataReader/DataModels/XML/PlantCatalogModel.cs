using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataReader.DataModels.XML
{
    [XmlRoot(ElementName = "CATALOG")]
	public class PlantCatalogModel
	{
		[XmlElement(ElementName = "PLANT")]
		public List<PlantModel> PLANT { get; set; }
	}


}
