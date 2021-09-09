using DataReader.DataAccess;
using DataReader.DataModels.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
                var productContent = _httpClientCommunicator.GetDataAsync().Result;
                ProductModel product = JsonConvert.DeserializeObject<ProductModel>(productContent.ToString());
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
       
        }

    }
}
