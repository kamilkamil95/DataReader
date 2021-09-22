using System;
using System.Xml.Serialization;

namespace DataReader.DataModels.XML
{
    [XmlRoot(ElementName = "PLANT")]
    public class PlantModel
    {
		[XmlElement(ElementName = "COMMON")]
		public string COMMON { get; set; }
		[XmlElement(ElementName = "BOTANICAL")]
		public string BOTANICAL { get; set; }
		[XmlElement(ElementName = "ZONE")]
		public string ZONE { get; set; }
		[XmlElement(ElementName = "LIGHT")]
		public string LIGHT { get; set; }
		[XmlElement(ElementName = "PRICE")]
		public string PRICE { get; set; }
		[XmlElement(ElementName = "AVAILABILITY")]
		public string AVAILABILITY { get; set; }
	}


}
