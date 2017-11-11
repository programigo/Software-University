namespace FootballBetting
{
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new FootballBettingDbContext())
            {
                db.Database.Migrate();
            }
        }
    }
}