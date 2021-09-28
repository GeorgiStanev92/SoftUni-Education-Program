namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public string State { get; }

        public void CompleteMission();
    }
}
