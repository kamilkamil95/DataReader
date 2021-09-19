using System.Xml.Serialization;
using System.Collections.Generic;

namespace DataReader.DataModels.XML
{
    [XmlRoot(ElementName = "CATALOG")]
	public class CATALOG
	{
		[XmlElement(ElementName = "PLANT")]
		public List<PLANT> PLANT { get; set; }
	}


}
