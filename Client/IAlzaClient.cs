using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
