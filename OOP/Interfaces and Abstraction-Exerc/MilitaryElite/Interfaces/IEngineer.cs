namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);
    }
}
