using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
{
    /// <summary>
    /// Interface for Alza QA team member
    /// </summary>
    internal interface IUser
    {
        public string? Name { get; }
        public string? Image { get; }
        public string? Description { get; }
    }
}
