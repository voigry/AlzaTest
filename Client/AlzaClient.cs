using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Client
{
    internal class AlzaClient: IDisposable, IAlzaClient
    {
        readonly RestClient _client;
        public AlzaClient()
        {
            var options = new RestClientOptions("https://webapi.alza.cz/api/career/");
            _client = new RestClient(options);
        }

        public RestClient ClientInstance => _client;

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
