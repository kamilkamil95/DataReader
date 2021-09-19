using DataReader.DataAccess;
using DataReader.DataModels.JSON;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace DataReader.Engine
{
    public class JsonReader : IJsonReader
    {
        IHttpClientCommunicator _httpClientCommunicator;

        public JsonReader(IHttpClientCommunicator httpClientCommunicator = null)
        {
            _httpClientCommunicator = httpClientCommunicator ?? new HttpClientCommunicator();
        }

        public bool ReadJson()
        {
            try
            {
                var productsContent = _httpClientCommunicator.GetDataAsync().Result;
                AllProductsModel products = JsonConvert.DeserializeObject<AllProductsModel>(productsContent.ToString());

                foreach (var item in products.data)
                {
                    Console.WriteLine($"-Type {item.id} to get some more informations about {item.name}.");
                }

                var choseProductReadKey = Console.ReadLine();
                try
                {
                    if (Convert.ToInt32(choseProductReadKey) <= products.data.Count)
                    {
                        ConsoleLogger.Success($"Your request was on product number {choseProductReadKey}");
                        var chosenProductData = products.data.FirstOrDefault(x => x.id == Convert.ToInt32(choseProductReadKey));
                        ConsoleLogger.Info(chosenProductData.id.ToString());
                        ConsoleLogger.Info(chosenProductData.name);
                        ConsoleLogger.Info(chosenProductData.year.ToString());
                        ConsoleLogger.Info(chosenProductData.pantone_value);
                        Console.ReadLine();
                    }
                    else
                    {
                        ConsoleLogger.Warning($"Please choose a number between 0 - {products.data.Count}");
                        NLoggerCommunicator.Info($"Chosen number was {choseProductReadKey}. Valid range is 0 - {products.data.Count}");
                        ConsoleLogger.Info("Press to continue....");
                        Console.ReadLine();
                        Console.Clear();
                        ReadJson();
                    }
                }
                catch (Exception x)
                {
                    ConsoleLogger.Warning("Please use numbers - more detalils you can find in error logs");
                    NLoggerCommunicator.Error(x);
                    Console.ReadLine();   
                }
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }

        }

    }
}
