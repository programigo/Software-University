using Microsoft.EntityFrameworkCore;

public class FootballBettingDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=.;Database=FootballBettingDb;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CountriesContinents>()
            .HasKey(cc => new { cc.CountryId, cc.ContinentId });

        builder.Entity<PlayerGame>()
            .HasKey(pg => new { pg.PlayerId, pg.GameId });

        builder.Entity<BetGame>()
            .HasKey(bg => new { bg.BetId, bg.GameId });

        builder
            .Entity<Team>()
            .HasOne(t => t.Town)
            .WithMany(tw => tw.Teams)
            .HasForeignKey(t => t.TownId);

        builder
            .Entity<Town>()
            .HasOne(t => t.Country)
            .WithMany(c => c.Towns)
            .HasForeignKey(t => t.CountryId);

        builder
            .Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.TeamId);

        builder
            .Entity<Player>()
            .HasOne(p => p.Position)
            .WithMany(po => po.Players)
            .HasForeignKey(p => p.PositionId);

        builder
            .Entity<Game>()
            .HasOne(g => g.Round)
            .WithMany(r => r.Games)
            .HasForeignKey(g => g.RoundId);

        builder
            .Entity<Game>()
            .HasOne(g => g.Competition)
            .WithMany(r => r.Games)
            .HasForeignKey(g => g.CompetitionId);

        builder
            .Entity<Bet>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bets)
            .HasForeignKey(b => b.UserId);
    }
}