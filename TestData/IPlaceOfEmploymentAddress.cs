namespace AlzaTest.TestData
{
    /// <summary>
    /// Interface for place of employment
    /// </summary>
    internal interface IPlaceOfEmploymentAddress
    {
        public string FullName { get; }
        public string Name { get; }

        public string StreetName { get; }

        public string StreetNumber { get; }

        public string City { get; }

        public string PostalCode { get; }

        public double latitude { get; }

        public double longitude { get; }

    }
}
