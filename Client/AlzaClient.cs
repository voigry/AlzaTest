using RestSharp;

namespace AlzaTest.Client
{
    /// <summary>
    /// Alza RestSharp rest client
    /// </summary>
    internal class AlzaClient : IDisposable, IAlzaClient
    {
        readonly RestClient _client;
        public AlzaClient()
        {
            var options = new RestClientOptions("https://webapi.alza.cz/api/career/");
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
