using Moq;
using NUnit.Framework;
using DataReader.DataAccess;
using System.Net.Http;
using DataReader.Engine;
using DataReader.DataModels.JSON;
using System;

namespace DataReaderTests
{
    
    public class Tests
    {
        private Mock<IHttpClientCommunicator> _httpClientCommunicator;
        private JsonReader _jsonReader;

        [SetUp]
        public void Setup()
        {
            _httpClientCommunicator = new Mock<IHttpClientCommunicator>();
            _jsonReader = new JsonReader(_httpClientCommunicator.Object);
        }

        //json
        [Test]
        public void GetDataAsync_HttpClient_ReturnsHttpRequestException()
        {
            _httpClientCommunicator.Setup(r => r.GetDataAsync()).Throws<HttpRequestException>();
            var result = _jsonReader.ReadJson();
            Assert.That(result, Is.False); ;
        }

        // jsooooon
        [Test]
        public void GetDataAsync_HttpClient_ReturnTrue()
        {
            JsonReader jsonReader = new JsonReader();
            var result = jsonReader.ReadJson();
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetDataAsync_ReturnsContent_TypeOfString()
        {
            HttpClientCommunicator httpClientCommunicator = new HttpClientCommunicator();
            var result = httpClientCommunicator.GetDataAsync();
            Assert.That(result.ToString(),Is.TypeOf<string>());
        }

      


    }
}