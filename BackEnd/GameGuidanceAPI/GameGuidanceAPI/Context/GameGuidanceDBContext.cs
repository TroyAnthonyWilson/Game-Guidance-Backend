using GameGuidanceAPI.Models;
using GameGuidanceAPI.Models.IGDB;
using Microsoft.EntityFrameworkCore;

namespace GameGuidanceAPI.Context
{
    public class GameGuidanceDBContext : DbContext
    {
        public GameGuidanceDBContext(DbContextOptions<GameGuidanceDBContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlayerPerspective> PlayerPerspectives { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserFavorite>().ToTable("user_favorites");
            modelBuilder.Entity<GameMode>().ToTable("gameModes");
            modelBuilder.Entity<Genre>().ToTable("genres");
            modelBuilder.Entity<PlayerPerspective>().ToTable("playerPerspectives");
            modelBuilder.Entity<Theme>().ToTable("themes");
        }
    }
}
