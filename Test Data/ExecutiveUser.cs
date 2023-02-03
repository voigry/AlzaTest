using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
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
