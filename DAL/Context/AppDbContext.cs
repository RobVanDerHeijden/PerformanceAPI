using Drafter.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Champion> Champions { get; set; }

        public DbSet<Rank> Ranks { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerChampion> PlayerChampions { get; set; }

        public DbSet<Team> Teams { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // UNCOMMENT THIS FOR MIGRATION STUFF
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=mssql.fhict.local;Initial Catalog=dbi413117;Persist Security Info=True;User ID=dbi413117;Password=Test321!;");
        }

        // For hasmanys etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: hier relaties mat hasmany etc proberen
            _ = modelBuilder.Entity<PlayerChampion>().HasKey(playerChampion => new { playerChampion.PlayerId, playerChampion.ChampionId });
            _ = modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team);
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}