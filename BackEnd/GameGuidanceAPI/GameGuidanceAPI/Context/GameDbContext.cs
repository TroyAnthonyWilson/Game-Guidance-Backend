using GameGuidanceAPI.Models.Game;
using Microsoft.EntityFrameworkCore;

namespace GameGuidanceAPI.Context
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<GameMode> GameModes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameMode>().ToTable("gameModes");
        }
    }
}
