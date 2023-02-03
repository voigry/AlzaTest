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
using System.Data;

namespace AlzaTest.Tests
{
    [TestFixtureSource(typeof(AlzaData), nameof(AlzaData.FixtureParams))]
    internal class TestAlzaJobPosition : AlzaBaseTest
    {
        private readonly string _segment;
        private readonly object _country;
        private readonly IJobItems _jobItems;
        private readonly IPlaceOfEmploymentAddress _placeOfEmployment;
        private readonly IUser _gestorUser;
        private readonly IUser _executiveUser;


        public TestAlzaJobPosition(string segment, object country, IJobItems jobItems, IPlaceOfEmploymentAddress placeOfEmployment, IUser gestorUser, IUser executiveUser) : base(segment, new AlzaClient().ClientInstance)
        {
            _segment = segment;
            _country = country;
            _jobItems = jobItems;
            _placeOfEmployment = placeOfEmployment;
            _gestorUser = gestorUser;
            _executiveUser = executiveUser;
        }

        [SetUp]
        public async Task SetUp()
        {
            Logger.Log($"Running test: {TestContext.CurrentContext.Test.MethodName}");
            Logger.Log($"Using segment: {_segment}");
            Logger.Log($"Using country: {_country}");
            Logger.Log($"With: {_jobItems}");
            Logger.Log($"With: {_placeOfEmployment}");
            var request = new RestRequest(_segment);
            request.AddObject(_country);
            var response = await Client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), $"Segement: {_segment}");

        }
        [Test]
        public async Task JobShouldNotBeSuitableForStudents()
        {
            var isSuitable = await Client.GetJsonAsync<ForStudents>( _segment);

            Assert.That(isSuitable?.forStudents, Is.False);
        }

        [Test]
        public async Task TestPopisPozice()
        {
            var ActualJobDescription = DecodeHtmlNodeToInnerText((string)(await GetJobItems())["items"][0]["content"], "//div[2]");

            Assert.That(ActualJobDescription.ToLower(), Is.EqualTo(_jobItems.JobDescription.ToLower()));

            Assert.That(ActualJobDescription, Is.EqualTo(_jobItems.JobDescription));

        }
        [Test]
        public async Task TestCoSeOdTebeOcekava()
        {
            JsonArray ActualWhaIsExpectedFromYou = await GetJobItemSubContent(2);

            AssertJobDescriptions(ActualWhaIsExpectedFromYou, _jobItems.WhatIsExpectedFromYou);

        }
        [Test]
        public async Task TestCoBudesMitVsechnoPodPalcemADoCehojdes()
        {
            JsonArray ActualWhatWilYouDo = await GetJobItemSubContent(1);

            AssertJobDescriptions(ActualWhatWilYouDo, _jobItems.WhatWilYouDo);
        }

        [Test]
        public async Task TestKdeBudePracovat()
        {
            PlaceOfEmployment? address = await Client.GetJsonAsync<PlaceOfEmployment>(_segment);
            Assert.That(address?.placeOfEmployment?.name?.ToLower(), Is.EqualTo(_placeOfEmployment.Name.ToLower()));

            AssertGeoPositions(address.placeOfEmployment.longitude, _placeOfEmployment.longitude);
            AssertGeoPositions(address.placeOfEmployment.latitude, _placeOfEmployment.latitude);
        }

        [Test]
        public async Task SkymSeNaPohovoruSetkas()
        {
            User actualGestorUser = await GetGestorUser();
            Logger.Log($"Assert that you will meet IT Recruiter {_gestorUser.Name}");
            Assert.That(actualGestorUser.name, Is.EqualTo(_gestorUser.Name));

            User actualExecutiveUser = await GetExecutiveUser();
            Logger.Log($"Assert that you will meet Head of QA {_executiveUser.Name}");
            Assert.That(actualExecutiveUser.name, Is.EqualTo(_executiveUser.Name));

            Employees people = await GetPeople();

            Logger.Log("You will also meet: ");
            foreach (User employee in people.items)
            {
                Logger.Log($"{employee.name}");
            }

            Assert.That(people.items.Count, Is.InRange(1, 20));
        }

    }

    public class AlzaData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData("v2/positions/softwarovy-tester", new { country = "cz" }, new JobItemsSoftwarovyTester(), new PlaceOfEmploymentCZPraha(), new GestorUser(), new ExecutiveUser());
                yield return new TestFixtureData("v2/positions/tester-mobilnich-aplikaci", new { country = "cz" }, new JobItemstesterMobilnichAplikaci(), new PlaceOfEmploymentCZPraha(), new GestorUser(), new ExecutiveUser());
                //yield return new TestFixtureData("positions/softwarovy-tester", (object) new { country = "en" });
            }
        }
    }



}
