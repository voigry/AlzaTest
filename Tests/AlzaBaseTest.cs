using AlzaTest.Client;
using AlzaTest.Loging;
using AlzaTest.Test_Data;
using AlzaTest.Deserializers;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlzaTest.Tests
{
    public class AlzaBaseTest
    {
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
        public async Task<JsonObject> GetJobItems(RestClient alzaClient, string segment)
        {
            var resp = await alzaClient.GetJsonAsync<PositionItemsHref>(segment);
            var positionItemsHref = resp.positionItems?["meta"]?["href"].ToString();
            JsonObject? items = await alzaClient.GetJsonAsync<JsonObject>(GetSegment(positionItemsHref));
            return items;
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
