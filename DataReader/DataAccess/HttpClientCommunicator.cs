using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataReader.DataAccess
{
   public class  HttpClientCommunicator : IHttpClientCommunicator
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<string> GetDataAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://reqres.in/api/products/2");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                return content;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\n Exception caught");
                Console.WriteLine("Message :{0} ", e.Message);
                NLoggerCommunicator.Error(e);
                return e.Message;

            }

        }

    }
}
