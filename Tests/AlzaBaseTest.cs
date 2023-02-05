using AlzaTest.Client;
using AlzaTest.Models;
using AlzaTest.Logging;
using HtmlAgilityPack;
using RestSharp;
using System.Net;
using System.Text.RegularExpressions;
using System.Text.Json.Nodes;
using System;
using System.Linq;

namespace AlzaTest.Tests
{
    /// <summary>
    /// Test Base for Alza tests.
    /// 
    /// </summary>
    internal class AlzaBaseTest
    {
        public RestClient Client { get; set; }
        public string _segment = string.Empty;

        public AlzaBaseTest() 
        {
            Client = new AlzaClient().Client;
        }
        public AlzaBaseTest(string segment) : this()
        {
            _segment = segment;
        }

        public string Segment
        {
            get { return _segment; }
            set { _segment = value; }
        }

        [SetUp]
        public void SetUpBase()
        {
            Logger.Log($"Start test with baseUrl: {Client.Options.BaseUrl}");
            Logger.Log($"Running test: {TestContext.CurrentContext.Test.MethodName}");
            Logger.Log($"Running with TestParameters: {TestContext.Parameters}");
        }
        public async Task<string> GetJobItemContent(int index)
        {
            return (string)(await GetJobItems())["items"][index]["content"];
        }
        /// <summary>
        /// Get subContent list of the job item
        /// </summary>
        /// <param name="index">Job items list index</param>
        /// <returns></returns>
        public async Task<JsonArray> GetJobItemSubContent(int index)
        {
            return (JsonArray)(await GetJobItems())["items"]?[index]["subContent"];
        }
        /// <summary>
        /// Decode string with html and return normalized inner text
        /// </summary>
        /// <param name="htmlString"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public string DecodeHtmlNodeToInnerText(string htmlString, string xpath)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(WebUtility.HtmlDecode(htmlString));
            var EncodedActualJobDescription = doc.DocumentNode.SelectSingleNode(xpath).InnerText.Normalize();
            return Regex.Replace(EncodedActualJobDescription, @"\s", " ");
        }
        /// <summary>
        /// Assert that geo positions are within a range
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public void AssertGeoPositions(double? actual, double expected)
        {
            var actualPosition = String.Format("{0:0.000}", Math.Round((double)actual, 2));
            var expectedPosition = String.Format("{0:0.000}", expected);
            Logger.Log($"Assert that actual position {actual} is in range to expected {expected}");
            Assert.That(actual, Is.InRange(expected - 0.01, expected + 0.01));
        }

        /// <summary>
        /// Get job items based on given segment
        /// </summary>
        /// <param name="alzaClient"></param>
        /// <param name="segment"></param>
        /// <returns>
        /// Items like What you will do, or job description
        /// </returns>
        public async Task<JsonObject> GetJobItems()
        {
            var resp = await Client.GetJsonAsync<PositionItemsHref>(Segment);
            var positionItemsHref = resp?.positionItems?["meta"]?["href"]?.ToString();
            JsonObject items = await Client.GetJsonAsync<JsonObject>(GetSegment(positionItemsHref));
            return items!;
        }
        /// <summary>
        /// Get IT Recruiter
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetGestorUser()
        {
            var resp = await Client.GetJsonAsync<GestorUserHref>(Segment);
            string? gestorUserHref = resp.gestorUser?["meta"]?["href"].ToString();
            User? user = await Client.GetJsonAsync<User>(gestorUserHref);
            return user;
        }
        /// <summary>
        /// Get Head of QA
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetExecutiveUser()
        {
            var resp = await Client.GetJsonAsync<ExecutiveUserHref>(Segment);
            string? executiveUserHref = resp.executiveUser?["meta"]?["href"].ToString();
            User? user = await Client.GetJsonAsync<User>(executiveUserHref);
            return user;
        }
        /// <summary>
        /// Get people
        /// </summary>
        /// <returns></returns>
        public async Task<Employees> GetPeople()
        {
            var resp = await Client.GetJsonAsync<PeopleHref>(Segment);
            string? peopleHref = resp.people?["meta"]?["href"].ToString();
            var jobPositionId = new Uri(peopleHref).Query.Split("=")[1];
            var args = new
            {
                jobPositionId = jobPositionId
            };
            var employeesHref = (string)(await Client.GetJsonAsync<JsonObject>(GetSegment(peopleHref), args))["meta"]["href"];

            return await Client.GetJsonAsync<Employees>(employeesHref);
        }
        /// <summary>
        /// Get segment from Href from initial record
        /// </summary>
        /// <param name="Href"></param>
        /// <returns></returns>
        public string GetSegment(string Href)
        {
            Uri positionItem = new Uri(Href);
            string segments = string.Join("", positionItem.Segments.Skip(3));
            Logger.Log($"Using segments: {segments}");
            return segments;
        }
        /// <summary>
        /// Assert that descriptions match
        /// </summary>
        /// <param name="Actual"></param>
        /// <param name="Expected"></param>
        public void AssertJobDescriptions(JsonArray Actual, string[] Expected)
        {
            Assert.That(Actual.Count, Is.EqualTo(Expected.Length), "Actual count of job expectations should be equal to expected lenght.");
            int i = 0;
            foreach (var item in Actual)
            {
                Logger.Log(item.ToString());
                Assert.That(item.ToString(), Is.EqualTo(Expected[i]));
                i++;
            }
        }
    }
}
