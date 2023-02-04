namespace AlzaTest.Deserializers
{
    internal class PlaceOfEmployment
    {
        public Address? placeOfEmployment { get; set; }
    }
    internal class Address
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? streetName { get; set; }
        public string? postalCode { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }



    }


}
