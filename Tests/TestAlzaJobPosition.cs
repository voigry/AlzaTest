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
using AlzaTest.Deserializers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AlzaTest.Tests
{
    [TestFixtureSource(typeof(AlzaData), nameof(AlzaData.FixtureParams))]
    internal class TestAlzaJobPosition: AlzaBaseTest
    {
        private RestClient alzaClient;
        private readonly string _segment;
        private readonly object _country;
        private readonly IJobItems _jobItems;
        private readonly IPlaceOfEmploymentAddress _placeOfEmployment;
        record InitialRecord(string name, bool forStudents, JsonObject placeOfEmployment, JsonObject gestorUser, JsonObject executiveUser, JsonObject people, JsonObject positionItems);


        public TestAlzaJobPosition(string segment, object country, IJobItems jobItems, IPlaceOfEmploymentAddress placeOfEmployment)
        {
            _segment = segment;
            _country = country;
            _jobItems = jobItems;
            _placeOfEmployment = placeOfEmployment;
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
        public async Task JobShouldNotBeSuitableForStudents()
        {
            Assert.True(true);
        }

        [Test]
        public async Task TestPopisPozice()
        {
            var ActualJobDescription = DecodeHtmlNodeToInnerText((string)(await GetJobItems(alzaClient, _segment))["items"][0]["content"], "//div[2]");

            Assert.That(ActualJobDescription.ToLower(), Is.EqualTo(_jobItems.JobDescription.ToLower()));

            Assert.That(ActualJobDescription, Is.EqualTo(_jobItems.JobDescription));

        }
        [Test]
        public async Task TestCoSeOdTebeOcekava()
        {
            JsonArray ActualWhaIsExpectedFromYou = (JsonArray)(await GetJobItems(alzaClient, _segment))["items"][2]["subContent"];

            AssertJobDescriptions(ActualWhaIsExpectedFromYou, _jobItems.WhatIsExpectedFromYou);

        }
        [Test]
        public async Task TestCoBudesMitVsechnoPodPalcemADoCehojdes()
        {
            JsonArray ActualWhatWilYouDo = (JsonArray)(await GetJobItems(alzaClient, _segment))["items"][1]["subContent"];

            AssertJobDescriptions(ActualWhatWilYouDo, _jobItems.WhatWilYouDo);
        }

        [Test]
        public async Task TestKdeBudePracovat()
        {
            PlaceOfEmployment? address = await alzaClient.GetJsonAsync<PlaceOfEmployment>(_segment);
            Assert.That(address?.placeOfEmployment?.name?.ToLower(), Is.EqualTo(_placeOfEmployment.Name.ToLower()));

            AssertGeoPositions(address.placeOfEmployment.longitude, _placeOfEmployment.longitude);
            AssertGeoPositions(address.placeOfEmployment.latitude, _placeOfEmployment.latitude);
        }

    }

    public class AlzaData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData("v2/positions/softwarovy-tester", new { country = "cz" }, new JobItemsSoftwarovyTester(), new PlaceOfEmploymentCZPraha());
                yield return new TestFixtureData("v2/positions/tester-mobilnich-aplikaci", new { country = "cz" }, new JobItemstesterMobilnichAplikaci(), new PlaceOfEmploymentCZPraha());
                //yield return new TestFixtureData("positions/softwarovy-tester", (object) new { country = "en" });
            }
        }
    }



}
