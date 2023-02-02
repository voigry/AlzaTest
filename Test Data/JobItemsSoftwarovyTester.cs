using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
{
    internal class JobItemsSoftwarovyTester : IJobItems
    {
        public JobItemsSoftwarovyTester()
        {

        }
        public string JobDescription
        {
            get => "Do týmu našich Quality Assurance Engineerů hledáme další schopné testery. Čeká Tě testování naší webové appky, budeš tedy zajišťovat, aby vše klapalo jak má :). Co Ti za to nabídneme? Profesní růst, moderní technologie, zkušenost s jedničky v e-commerce na trhu a skvělý kolektiv k tomu!";
        }

        public string[] WhatWilYouDo
        {
            get => new string[]
            {
                "Test cases, testovací analýzy a scénáře, analýza a reprodukce nalezených chyb",
                "Reporting výsledků testů",
                "Údržba testovacího prostředí a psaní dokumentace",
                "A nakonec budete společně vývojovým týmem nastavovat preventivní opatření aby se chybám předcházelo :)"
            };
        }
        public string[] WhatIsExpectedFromYou
        {
            get => new string[]
            {
                "Alespoň 2 roky zkušeností s testováním",
                "Máš za sebou praktickou zkušenost s testováním webových služeb",
                "Česky mluvíš na úrovni rodilého mluvčího a angličtinu máš alespoň na úrovni B2",
                "Dovedeš si nastavit priority, dotahuješ práci do konce, odvádíš pečlivou práci",
                "Malý bonus, pokud ses v praxi setkal/a s test management systémem a orientuješ se v C#, NUnit, .NET Core"
            };
        }
        public string[] WhatYouWillGet
        {
            get => new string[]
            {
                "Jsme jedničkou na trhu v oblasti e-commerce a ty můžeš být naší součástí",
                "Skvělý tým kolegů, kteří jsou špičkou ve svém oboru",
                "Neformální pracovní prostředí bez politiky a zdlouhavých procesů",
                "Kanceláře v Holešovicích, kde máme vlastní kavárnu, posilovnu, saunu, lezeckou stěnu a další možnosti k odreagování se",
                "Slevy na Alza.cz a Alzabox přímo v kanceláři",
                "Flexibilní pracovní dobu a home office"
            };
        }
    }
}
