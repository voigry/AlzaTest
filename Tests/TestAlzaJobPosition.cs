using AlzaTest.Client;
using AlzaTest.Loging;
using AlzaTest.Test_Data;
using HtmlAgilityPack;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AlzaTest.Tests
{
    [TestFixtureSource(typeof(AlzaData), nameof(AlzaData.FixtureParams))]
    public class TestAlzaJobPosition
    {
        private RestClient alzaClient;
        private readonly string _segment;
        private readonly object _country;
        record InitialRecord(string name, bool forStudents, JsonObject placeOfEmployment, JsonObject gestorUser, JsonObject executiveUser, JsonObject people, JsonObject positionItems);


        public TestAlzaJobPosition(string segment, object country)
        {
            _segment = segment;
            _country = country;
        }

        [SetUp]
        public async Task SetUp()
        {
            alzaClient = new AlzaClient().ClientInstance;
            Console.WriteLine(_segment);

            Assert.IsNotNull(_country);

            object args = _country;

            var request = new RestRequest(_segment);
            request.AddObject(args);
            var response = await alzaClient.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), $"Segement: {_segment}");


            
            //InitialRecord initialRecord = await alzaClient.GetJsonAsync<InitialRecord>(_segment, args);

            /*
            var name = initialRecord?.name;
            var forStudents = initialRecord?.forStudents;
            _placeOfEmployment = initialRecord.placeOfEmployment;
            var gestorUserUrl = initialRecord?.gestorUser?["meta"]?["href"];
            var executiveUserUrl = initialRecord?.executiveUser?["meta"]?["href"];
            var people = initialRecord?.people?["meta"]?["href"];
            _positionItemsHref = initialRecord?.positionItems?["meta"]?["href"].ToString();
            */

            //Assert.That(name, Is.EqualTo("Softwarový Tester"));

        }

        [Test]
        public async Task TestPopisPozice()
        {
            var ActualJobDescription = (string)(await GetJobItems())["items"][0]["content"];
            HtmlDocument doc = new HtmlDocument();
            
            doc.LoadHtml(ActualJobDescription);
            var EncodedActualJobDescription = doc.DocumentNode.SelectSingleNode("//div[2]").InnerText;
            Assert.That(EncodedActualJobDescription, Is.EqualTo(JobItems.JobDescription));

        }
        [Test]
        public async Task TestCoSeOdTebeOcekava()
        {
            JsonArray ActualWhaIsExpectedFromYou = (JsonArray)(await GetJobItems())["items"][2]["subContent"];

            AssertJobDescriptions(ActualWhaIsExpectedFromYou, JobItems.WhatIsExpectedFromYou);

        }
        [Test]
        public async Task TestCoBudesMitVsechnoPodPalcemADoCehojdes()
        {
            JsonArray ActualWhatWilYouDo = (JsonArray)(await GetJobItems())["items"][1]["subContent"];

            AssertJobDescriptions(ActualWhatWilYouDo, JobItems.WhatWilYouDo);
        }

        [Test]
        public async Task TestKdeBudePracovat()
        {
            Assert.IsTrue(true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task<JsonObject> GetJobItems()
        {
            var resp = await alzaClient.GetJsonAsync<JobItems.PositionItemsHref>(_segment);
            var positionItemsHref = resp.positionItems?["meta"]?["href"].ToString();
            JsonObject? items = await alzaClient.GetJsonAsync<JsonObject>(GetSegment(positionItemsHref));
            return items!;
        }

        /// <summary>
        /// Get segment from Href from initial record
        /// </summary>
        /// <param name="Href"></param>
        /// <returns></returns>
        private string GetSegment(string Href)
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
        private void AssertJobDescriptions(JsonArray Actual, string[] Expected)
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

    public class AlzaData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData("v2/positions/softwarovy-tester", new { country = "cz" });
                yield return new TestFixtureData("v2/positions/tester-mobilnich-aplikaci", new { country = "cz" });
                //yield return new TestFixtureData("positions/softwarovy-tester", (object) new { country = "en" });
            }
        }
    }



}
