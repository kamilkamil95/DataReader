using Autofac;
using DataReader.DataAccess;
using DataReader.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    public static class ContainerConfig
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<JsonReader>().As<IJsonReader>();
            builder.RegisterType<XmlDocumentReader>().As<XmlDocumentReader>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<HttpClientCommunicator>().As<IHttpClientCommunicator>();
            return builder.Build();

        }



    }
}
