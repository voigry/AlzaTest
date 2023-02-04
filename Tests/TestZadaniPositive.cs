using AlzaTest.Deserializers;
using AlzaTest.Logging;
using AlzaTest.Test_Data;
using RestSharp;

namespace AlzaTest.Tests
{
    [TestFixture("v2/positions/softwarovy-tester")]
    internal class TestZadaniPositive : AlzaBaseTest
    {
        public TestZadaniPositive(string segment) : base(segment) { }

        [SetUp]
        public void SetUp()
        {
            Logger.Log($"Using segment: {Segment}");

        }

        [Test]
        [TestCaseSource(typeof(JobTestCaseData), nameof(JobTestCaseData.JobItemsSoftwarovyTester))]
        public async Task TestPopisPozice(IJobItems jobItems)
        {
            var ActualJobDescription = DecodeHtmlNodeToInnerText(await GetJobItemContent(0), "//div[2]");
            Logger.Log($"Očekávaný popis pozice {jobItems.JobDescription}");

            Assert.That(ActualJobDescription.ToLower(), Is.EqualTo(jobItems.JobDescription.ToLower()));

            Assert.That(ActualJobDescription, Is.EqualTo(jobItems.JobDescription));

        }
        [Test]
        [TestCaseSource(typeof(JobTestCaseData), nameof(JobTestCaseData.KdeBudesPracovat))]
        public async Task TestKdeBudePracovat(IPlaceOfEmploymentAddress placeOfEmployment)
        {
            PlaceOfEmployment? address = await Client.GetJsonAsync<PlaceOfEmployment>(Segment);
            Logger.Log($"Očekávané místo práce {placeOfEmployment.FullName}");

            Assert.That(address?.placeOfEmployment?.name?.ToLower(), Is.EqualTo(placeOfEmployment.Name.ToLower()));

            AssertGeoPositions(address.placeOfEmployment.longitude, placeOfEmployment.longitude);
            AssertGeoPositions(address.placeOfEmployment.latitude, placeOfEmployment.latitude);
        }

        [TestCaseSource(typeof(JobTestCaseData), nameof(JobTestCaseData.KohoNaPohovoruPotkas))]
        public async Task SkymSeNaPohovoruSetkas(IUser gestor, IUser executive)
        {
            User actualGestorUser = await GetGestorUser();
            Logger.Log($"IT Recruiter {gestor.Name}");
            Logger.Log($"{gestor.Description}");

            Assert.That(actualGestorUser.name, Is.EqualTo(gestor.Name));

            User actualExecutiveUser = await GetExecutiveUser();
            Logger.Log($"Head of QA {executive.Name}");
            Logger.Log($"{executive.Description}");

            Assert.That(actualExecutiveUser.name, Is.EqualTo(executive.Name));
        }
        [Test]
        public async Task JobShouldNotBeSuitableForStudents()
        {
            var isSuitable = await Client.GetJsonAsync<ForStudents>(_segment);

            Assert.That(isSuitable?.forStudents, Is.False);
        }
    }
}
