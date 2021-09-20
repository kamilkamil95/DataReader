using Moq;
using NUnit.Framework;
using DataReader.DataAccess;
using System.Net.Http;
using DataReader.Engine;
using DataReader.DataModels.JSON;
using System;
using DataReader;

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

        [Test]
        public void GetDataAsync_ReturnsContent_TypeOfString()
        {
            HttpClientCommunicator httpClientCommunicator = new HttpClientCommunicator();
            var result = httpClientCommunicator.GetDataAsync(Consts.JsonApiUrl);
            Assert.That(result.ToString(),Is.TypeOf<string>());
        }

        [Test]
        public void GetDataAsync_HttpClient_ReturnsHttpRequestException()
        {
          _httpClientCommunicator.Setup(r => r.GetDataAsync(Consts.JsonApiUrl)).Throws<HttpRequestException>();
          Assert.Throws<HttpRequestException>(() => _httpClientCommunicator.Object.GetDataAsync(Consts.JsonApiUrl));

        }


    }
}