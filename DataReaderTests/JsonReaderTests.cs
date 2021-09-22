using DataReader;
using DataReader.DataAccess;
using DataReader.Engine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataReaderTests
{
    class JsonReaderTests
    {

        private Mock<IHttpClientCommunicator> _httpClientCommunicator;
        private JsonReader _jsonReader;

        [SetUp]
        public void Setup()
        {
            _httpClientCommunicator = new Mock<IHttpClientCommunicator>();
            _jsonReader = new JsonReader(_httpClientCommunicator.Object);
        }

        
        [Test]
        public void JsonReader_ReadJson_ReturnsHttpRequestException()
        {
            _httpClientCommunicator.Setup(r => r.GetDataAsync(Consts.JsonApiUrl)).Throws<HttpRequestException>();
            var result = _jsonReader.ReadJson();
            Assert.That(result, Is.False); ;
        }

        [TestCase("1", true)]
        [TestCase("222222", false)]
        [TestCase("b", false)]
        public void JsonReader_ReadJson_ValidNumbersReturnsTrue(string inputValue, bool expectedResult)
        {
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader(inputValue);
            Console.SetIn(input);
            JsonReader jsonReader = new JsonReader();
            var result = jsonReader.ReadJson();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
