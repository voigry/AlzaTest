using AlzaTest.Logging;
using RestSharp;

namespace AlzaTest.Tests
{




    [TestFixture]
    internal class TestZadaniNegative : AlzaBaseTest
    {
        public TestZadaniNegative() : base()
        {

        }

        [TestCase("v2/positions/softwarovy-tester")]
        public async Task TestValidSegment(string segment)
        {
            Logger.Log($"Using segment: {segment}");

            var request = new RestRequest(segment).AddQueryParameter("country", "cz");
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), $"Segement: {segment}");
        }

        [TestCase("v2/positions/softwarovy-mag")]
        public async Task TestInvalidSegment(string segment)
        {
            Logger.Log($"Using segment: {segment}");

            var request = new RestRequest(segment).AddQueryParameter("country", "cz");
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), $"Segement: {segment}");


        }

        [TestCase("v2/positions/softwarovy-tester", "CzechiaCZ")]
        public async Task TestInvalidCountry(string segment, string country)
        {
            Logger.Log($"Using segment: {segment}");
            Logger.Log($"Using country: {country}");

            var request = new RestRequest(segment).AddQueryParameter("country", country);
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), $"Country: {country}");


        }
    }
}
