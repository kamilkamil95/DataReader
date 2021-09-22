using DataReader.DataAccess;
using DataReader.Engine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReaderTests
{
    public class XmlDocumentReaderTests
    {
       private Mock<IHttpClientCommunicator> _httpClientCommunicator;
       private XmlDocumentReader _xmlDocumentReader;

        [SetUp]
        public void Setup()
        {
            _httpClientCommunicator = new Mock<IHttpClientCommunicator>();
            _xmlDocumentReader = new XmlDocumentReader();
        }

            [TestCase("15", true)]
            [TestCase("9999", false)]
            [TestCase("Z", false)]
            public void ReadXml_ValidNumbersReturnsTrueOrFalse(string inputValue, bool expectedResult)
            {
                var output = new StringWriter();
                Console.SetOut(output);
                var input = new StringReader(inputValue);
                Console.SetIn(input);
                var result = _xmlDocumentReader.ReadXml();
                Assert.AreEqual(expectedResult, result);
            }
        


    }
}
