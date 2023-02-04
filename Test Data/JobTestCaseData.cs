using System.Collections;

namespace AlzaTest.Test_Data
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
