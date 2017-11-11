namespace FootballBetting.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;

    [DbContext(typeof(FootballBettingDbContext))]
    partial class FootballBettingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BetMoney");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("BetGame", b =>
                {
                    b.Property<int>("BetId");

                    b.Property<int>("GameId");

                    b.Property<int>("ResultPredictionId");

                    b.HasKey("BetId", "GameId");

                    b.HasIndex("GameId");

                    b.HasIndex("ResultPredictionId");

                    b.ToTable("BetGame");
                });

            modelBuilder.Entity("Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetitionTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionTypeId");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("CompetitionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompetitionType");
                });

            modelBuilder.Entity("Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("CountriesContinents", b =>
                {
                    b.Property<int>("CountryId");

                    b.Property<int>("ContinentId");

                    b.Property<string>("CountryId1");

                    b.HasKey("CountryId", "ContinentId");

                    b.HasIndex("ContinentId");

                    b.HasIndex("CountryId1");

                    b.ToTable("CountriesContinents");
                });

            modelBuilder.Entity("Country", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AwayGoals");

                    b.Property<int?>("AwayTeamId");

                    b.Property<double>("AwayTeamWinBetRate");

                    b.Property<int>("CompetitionId");

                    b.Property<DateTime>("DateTime");

                    b.Property<double>("DrawGameBetRate");

                    b.Property<int>("HomeGoals");

                    b.Property<int?>("HomeTeamId");

                    b.Property<double>("HomeTeamWinBetRate");

                    b.Property<int>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("RoundId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsInjured");

                    b.Property<string>("Name");

                    b.Property<string>("PositionId");

                    b.Property<int>("SquadNumber");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("PlayerGame", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameId");

                    b.HasKey("PlayerId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("PlayerGame");
                });

            modelBuilder.Entity("Position", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionDescription");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("ResultPrediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Prediction");

                    b.HasKey("Id");

                    b.ToTable("ResultPrediction");
                });

            modelBuilder.Entity("Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget");

                    b.Property<string>("Initials");

                    b.Property<byte>("Logo");

                    b.Property<string>("Name");

                    b.Property<int>("PrimaryColorId");

                    b.Property<int?>("PrimaryKitColorId");

                    b.Property<int>("SecondaryColorId");

                    b.Property<int?>("SecondaryKitColorId");

                    b.Property<int>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("PrimaryKitColorId");

                    b.HasIndex("SecondaryKitColorId");

                    b.HasIndex("TownId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bet", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BetGame", b =>
                {
                    b.HasOne("Bet", "Bet")
                        .WithMany("Games")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Game", "Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ResultPrediction", "ResultPrediction")
                        .WithMany()
                        .HasForeignKey("ResultPredictionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Competition", b =>
                {
                    b.HasOne("CompetitionType", "CompetitionType")
                        .WithMany()
                        .HasForeignKey("CompetitionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CountriesContinents", b =>
                {
                    b.HasOne("Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Country", "Country")
                        .WithMany("Continents")
                        .HasForeignKey("CountryId1");
                });

            modelBuilder.Entity("Game", b =>
                {
                    b.HasOne("Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("Competition", "Competition")
                        .WithMany("Games")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("Round", "Round")
                        .WithMany("Games")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Player", b =>
                {
                    b.HasOne("Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId");

                    b.HasOne("Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlayerGame", b =>
                {
                    b.HasOne("Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Player", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Team", b =>
                {
                    b.HasOne("Color", "PrimaryKitColor")
                        .WithMany()
                        .HasForeignKey("PrimaryKitColorId");

                    b.HasOne("Color", "SecondaryKitColor")
                        .WithMany()
                        .HasForeignKey("SecondaryKitColorId");

                    b.HasOne("Town", "Town")
                        .WithMany("Teams")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Town", b =>
                {
                    b.HasOne("Country", "Country")
                        .WithMany("Towns")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}