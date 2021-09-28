namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }

        void AddMission(IMission mission);
    }
}
