using AlzaTest.Loging;
using AlzaTest.Test_Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AlzaTest.Tests
{
    [TestFixture("v2/positions/softwarovy-tester")]
    internal class TestZadaniPositive : AlzaBaseTest
    {
        private readonly IJobItems _jobItems;
        public TestZadaniPositive(string segment) : base(segment)
        {
            _jobItems = new JobItemsSoftwarovyTester();
        }

        [SetUp]
        public void SetUp()
        {
            Logger.Log($"Using segment: {Segment}");

        }

        [Test]
        public async Task TestPopisPozice()
        {
            var ActualJobDescription = DecodeHtmlNodeToInnerText(await GetJobItemContent(0), "//div[2]");

            Assert.That(ActualJobDescription.ToLower(), Is.EqualTo(_jobItems.JobDescription.ToLower()));

            Assert.That(ActualJobDescription, Is.EqualTo(_jobItems.JobDescription));

        }
    }

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

        [TestCase("v2/positions/softwarovy-tester")]
        public async Task TestInvalidCountry(string segment)
        {
            Logger.Log($"Using segment: {segment}");

            var request = new RestRequest(segment).AddQueryParameter("country", "DDR");
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), $"Segement: {segment}");


        }
    }
}
