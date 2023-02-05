using AlzaTest.Logging;
using AlzaTest.TestData;
using RestSharp;


namespace AlzaTest.Tests
{
    /// <summary>
    /// Test reusability and extensibility when adding new test class
    /// </summary>
    /// 
    [TestFixture("v2/positions/softwarovy-tester")]
    internal class TestReusabilityAndExtensibilityWithTestFixtureParam : AlzaBaseTest
    {
        public TestReusabilityAndExtensibilityWithTestFixtureParam(string segment) : base(segment)
        {

        }

        [SetUp]
        public void SetUp()
        {
            Logger.Log($"Using segment: {Segment}");
        }

        [Test]
        public async Task TestWithNoParam()
        {
            Logger.Log("New Test comment");
            System.Text.Json.Nodes.JsonArray ActualWhatWilYouDo = await GetJobItemSubContent(1);

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
        public async Task TestWithParam(string segment)
        {
            Logger.Log($"Using segment: {segment}");

            var request = new RestRequest(segment).AddQueryParameter("country", "cz");
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), $"Segement: {segment}");
        }
    }
}
