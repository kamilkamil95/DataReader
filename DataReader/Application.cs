using DataReader.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    public class Application : IApplication
    {
        IJsonReader _jsonReader;

        public Application(IJsonReader jsonReader)
        {
            _jsonReader = jsonReader;
        }

        public void Run()
        {
            _jsonReader.ReadJsonAsync();
        }


    }
}
