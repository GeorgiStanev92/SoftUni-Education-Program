using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            System.Console.WriteLine("asd");
        }
    }
}
