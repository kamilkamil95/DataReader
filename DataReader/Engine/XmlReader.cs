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
    class XmlReader : IXmlReader
    {

        IHttpClientCommunicator _httpClientCommunicator;

        public XmlReader(IHttpClientCommunicator httpClientCommunicator = null)
        {
            _httpClientCommunicator = httpClientCommunicator ?? new HttpClientCommunicator();
        }

        public bool ReadXml()
        {
            var PlantCatalog = GetDeserializedModel();
            int decision = 0;

            if(PlantCatalog.PLANT.Count != 0)
            {
                for (int i = 0; i < PlantCatalog.PLANT.Count-1; i++)
                {
                    ConsoleLogger.Info($"- Type {i} to view details about - {PlantCatalog.PLANT[i].COMMON}");
                }
                Console.WriteLine($"Please chose a number between 1 - {PlantCatalog.PLANT.Count}");

                try
                {
                    decision = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    NLoggerCommunicator.Error(ex);
                    ConsoleLogger.Warning("Please Chose mentioned number");
                }
               
                if(decision <= PlantCatalog.PLANT.Count)
                {
                    ConsoleLogger.Info("");
                    ConsoleLogger.Info(PlantCatalog.PLANT[decision].COMMON);
                    ConsoleLogger.Info(PlantCatalog.PLANT[decision].BOTANICAL);
                    ConsoleLogger.Info(PlantCatalog.PLANT[decision].AVAILABILITY);
                    ConsoleLogger.Info(PlantCatalog.PLANT[decision].PRICE);
                }
            }        
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
