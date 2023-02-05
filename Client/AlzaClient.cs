using System;
using RestSharp;

namespace AlzaTest.Client
{
    /// <summary>
    /// Alza RestSharp rest client
    /// </summary>
    internal class AlzaClient : IDisposable, IAlzaClient
    {
        readonly RestClient _client;
        private string _baseUrl = "Not Defined";
        public TestContext? TestContext { get; set; }
        public AlzaClient()
        {
            _baseUrl = TestContext.Parameters["baseUrl"];
            var options = new RestClientOptions(baseUrl: _baseUrl);
            _client = new RestClient(options);
        }

        public RestClient Client
        {
            get { return _client; }
        }


        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
