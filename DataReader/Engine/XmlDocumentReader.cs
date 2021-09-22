using DataReader.DataAccess;
using DataReader.DataModels.XML;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DataReader.Engine
{
    public class XmlDocumentReader : IXmlDocumentReader
    {
        IHttpClientCommunicator _httpClientCommunicator;

        public XmlDocumentReader(IHttpClientCommunicator httpClientCommunicator = null)
        {
            _httpClientCommunicator = httpClientCommunicator ?? new HttpClientCommunicator();
        }

        public bool ReadXml()
        {
            var PlantCatalog = GetDeserializedModel();

            if(PlantCatalog.PLANT.Count != 0)
            {
                for (int i = 0; i < PlantCatalog.PLANT.Count; i++)
                {
                    ConsoleLogger.Info($"- Type {i} to view details about - {PlantCatalog.PLANT[i].COMMON}");
                }
                Console.WriteLine($"Please chose a number between 1 - {PlantCatalog.PLANT.Count-1}");
                try
                {
                    var decisionNumber = Convert.ToInt32(Console.ReadLine());
                        ConsoleLogger.Info("");
                        ConsoleLogger.Info(PlantCatalog.PLANT[decisionNumber].COMMON);
                        ConsoleLogger.Info(PlantCatalog.PLANT[decisionNumber].BOTANICAL);
                        ConsoleLogger.Info(PlantCatalog.PLANT[decisionNumber].AVAILABILITY);
                        ConsoleLogger.Info(PlantCatalog.PLANT[decisionNumber].PRICE);
                }
                catch (Exception ex)
                {
                    NLoggerCommunicator.Error(ex);
                    ConsoleLogger.Warning("Please Chose mentioned number");
                    return false;
                }
            }
            ConsoleLogger.Success("Press to continue");
            Console.ReadLine();
            return true;
        }

        private PlantCatalogModel GetDeserializedModel()
        {
            var productsContent = _httpClientCommunicator.GetDataAsync(Consts.XmlApiUrl).Result;
            XmlSerializer serializer = new XmlSerializer(typeof(PlantCatalogModel));
            PlantCatalogModel PlantCatalog;

            try
            {
                using (StringReader reader = new StringReader(productsContent))
                {
                    PlantCatalog = (PlantCatalogModel)serializer.Deserialize(reader);
                    return PlantCatalog;
                }
            }
            catch (Exception ex)
            {
                NLoggerCommunicator.Error(ex);
                ConsoleLogger.ErrorHandler(ex);
                
            }
            return new PlantCatalogModel();
        }
    }
}
