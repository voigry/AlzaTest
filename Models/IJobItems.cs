namespace AlzaTest.Models
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
