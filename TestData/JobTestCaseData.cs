using System.Collections;
using AlzaTest.Models;

namespace AlzaTest.TestData
{
    public class JobTestCaseData
    {
        public static IEnumerable JobItemsSoftwarovyTester
        {
            get
            {
                yield return new TestCaseData(new JobItemsSoftwarovyTester());
            }
        }
        public static IEnumerable KdeBudesPracovat
        {
            get
            {
                yield return new TestCaseData(new PlaceOfEmploymentCZPraha());
            }
        }

        public static IEnumerable KohoNaPohovoruPotkas
        {
            get
            {
                yield return new TestCaseData(new GestorUser(), new ExecutiveUser());
            }
        }

    }
}
