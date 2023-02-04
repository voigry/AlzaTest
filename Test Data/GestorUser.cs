namespace AlzaTest.Test_Data
{
    /// <summary>
    /// Define IT Recruiter
    /// </summary>
    internal class GestorUser : IUser
    {
        public GestorUser() { }

        public string Name
        {
            get => "Řihová Simona";
        }
        public string Image
        {
            get => "image";
        }
        public string Description
        {
            get => "Ahoj, som Simča a v Alze zastrešujem nábor pre naše IT oddelenie. Mám rada humor, svoju rannú kávu a prírodu.";
        }
    }
}
