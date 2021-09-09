using DataReader.DataAccess;
using DataReader.DataModels.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.Engine
{
    class JsonReader : IJsonReader
    {
        IHttpClientCommunicator _httpClientCommunicator;

        public JsonReader(IHttpClientCommunicator httpClientCommunicator)
        {
            _httpClientCommunicator = httpClientCommunicator;
        }

        public async Task ReadJsonAsync()
        {
         var productContent = await _httpClientCommunicator.GetDataAsync();
         ProductModel product = JsonConvert.DeserializeObject<ProductModel>(productContent.ToString());

        }

    }
}
