using DataReader.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



            return true;
        }


    }

}
