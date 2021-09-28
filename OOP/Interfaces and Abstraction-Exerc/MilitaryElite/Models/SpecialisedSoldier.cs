namespace MilitaryElite.Models
{
    using MilitaryElite.Interfaces;
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corp { get; set; }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary)
        {
            Corp = corp;
        }
    }
}
