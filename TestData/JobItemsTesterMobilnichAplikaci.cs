using AlzaTest.Models;

namespace AlzaTest.TestData
{
    /// <summary>
    /// Define test data for position TesterMobilnichAplikaci. Data here are incomplete as given endopoint tester-mobilnich-aplikaci does not return position
    /// </summary>
    internal class JobItemsTesterMobilnichAplikaci : IJobItems
    {
        public JobItemsTesterMobilnichAplikaci()
        {

        }
        public string JobDescription
        {
            get => "Jsme Alza. Provozujeme největší český e-shop postavený na vlastním know-how, který neustále rozvíjíme ...";
        }

        public string[] WhatWilYouDo
        {
            get => new string[]
            {
                "Psaní test casů, testovacích analýz, scénářů a dokumentace pro manuální a automatizované testy",
                "Reprodukce a analýza reportovaných chyb, které k nám přichází a zároveň nastavení preventivních opatřeními ve spolupráci s vývojovým týmem"

            };
        }
        public string[] WhatIsExpectedFromYou
        {
            get => new string[]
            {
                "Máš rád/a různorodou práci ",
                "Máš dobrý self-management a umíš prioritizovat",
                "Mluvíš plynule česky"
            };
        }
        public string[] WhatYouWillGet
        {
            get => new string[]
            {
                "Příspěvky na nákup zboží na Alza.cz",
                "Skvělý tým kolegů, kteří jsou špičkou ve svém oboru",
                "Příspěvek na stravování "

            };
        }
    }
}
