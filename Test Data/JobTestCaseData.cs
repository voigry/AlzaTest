using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
