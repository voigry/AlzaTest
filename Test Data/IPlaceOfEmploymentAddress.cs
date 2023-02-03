using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
{
    /// <summary>
    /// Interface for place of employment
    /// </summary>
    internal interface IPlaceOfEmploymentAddress
    {
        public string Name { get; }

        public string StreetName { get; }

        public string StreetNumber { get; }

        public string City { get; }

        public string PostalCode { get; }

        public double latitude { get; }

        public double longitude { get; }

    }
}
