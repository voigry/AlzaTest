namespace AlzaTest.Models
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
