namespace AlzaTest.Test_Data
{
    /// <summary>
    /// Define place of employment for CZ Praha Holesovice. 
    /// Full address from Mapy.cz U Pergamenky 1522/2, Praha – Holešovice, 170 00
    /// </summary>
    internal class PlaceOfEmploymentCZPraha : IPlaceOfEmploymentAddress
    {

        public PlaceOfEmploymentCZPraha()
        {

        }
        public string FullName
        {
            get => "Hall office park, U Pergamenky 1522/2, Praha – Holešovice, 170 00";
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
        /// <summary>
        /// Latitude from Mapy.cz 50.1084772N
        /// </summary>
        public double latitude
        {
            get => 50.110;
        }
        /// <summary>
        /// Longitude from Mapy.cz 14.4516217E
        /// </summary>
        public double longitude
        {
            get => 14.453;
        }
    }
}
