using AlzaTest.Models;

namespace AlzaTest.TestData
{
    /// <summary>
    /// Define Head of QA
    /// </summary>
    internal class ExecutiveUser : IUser
    {
        public ExecutiveUser() { }

        public string Name
        {
            get => "Tomusko Ján";
        }
        public string Image
        {
            get => "image";
        }
        public string Description
        {
            get => "";
        }
    }
}
