using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
{
    internal class PlaceOfEmploymentCZPraha : IPlaceOfEmploymentAddress
    {
        //U Pergamenky 1522/2, Praha – Holešovice, 170 00
        //50.1084772N, 14.4516217E
        //50.108450000,14.452610000
        /// <summary>
        /// Data for job position 
        /// </summary>
        /// 
        public PlaceOfEmploymentCZPraha() 
        {

        }

        public string Name
        {
            get => "Hall office park";
        }
        public string StreetName
        {
            get => "U Pergamenky";
        }
        public string StreetNumber
        {
            get => "1522/2";
        }
        public string City
        {
            get => "Praha";
        }
        public string State
        {
            get => "Česká republika";
        }
        public string PostalCode
        {
            get => "17000";
        }
        public double latitude
        {
            get => 50.110;
        }
        public double longitude
        {
            get => 14.453;
        }
    }
}
