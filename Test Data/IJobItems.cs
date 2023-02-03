using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlzaTest.Test_Data
{
    /// <summary>
    /// Interface for Job items describing given job position
    /// </summary>
    public interface IJobItems
    {
        string JobDescription { get; }
        string[] WhatWilYouDo { get; }
        string[] WhatIsExpectedFromYou { get; }
        string[] WhatYouWillGet { get; }
    }
}
