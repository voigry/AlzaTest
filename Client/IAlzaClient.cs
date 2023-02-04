using RestSharp;

namespace AlzaTest.Client
{
    /// <summary>
    /// Interface for Alza RestSharp rest client
    /// </summary>
    internal interface IAlzaClient
    {
        public RestClient Client { get; }
    }
}
