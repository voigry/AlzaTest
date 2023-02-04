using AlzaTest.Client;
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
    /// <summary>
    /// Test reusability and extensibility when adding new test class
    /// </summary>
    /// 
    [TestFixture("v2/positions/softwarovy-tester")]
    internal class TestReusabilityAndExtensibility : AlzaBaseTest
    {
        public TestReusabilityAndExtensibility(string segment) : base(segment)
        {

        }

        [SetUp]
        public void SetUp()
        {
            Logger.Log($"Using segment: {Segment}");
        }

        [Test]
        public async Task NewTest()
        {
            Logger.Log("New Test comment");
            JsonArray ActualWhatWilYouDo = await GetJobItemSubContent(1);

            AssertJobDescriptions(ActualWhatWilYouDo, new JobItemsSoftwarovyTester().WhatWilYouDo);
        }     
    }

    [TestFixture]
    internal class TestReusabilityAndExtensibilityBasic : AlzaBaseTest
    {
        public TestReusabilityAndExtensibilityBasic() : base()
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
    }
}
