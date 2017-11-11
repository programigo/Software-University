namespace _04.FirstAndReserveTeam
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int numberOfPlayers = int.Parse(Console.ReadLine());

            Team team = new Team("Rozite");

             for (int i = 0; i < numberOfPlayers; i++)
             {
                 string[] playerInfo = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            
                 Person player = new Person(playerInfo[0], playerInfo[1], int.Parse(playerInfo[2]), double.Parse(playerInfo[3]));
            
                 team.AddPlayer(player);
             }
            
             Console.WriteLine($"First team have {team.FirstTeam.Count} players");
             Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
        }
    }
}