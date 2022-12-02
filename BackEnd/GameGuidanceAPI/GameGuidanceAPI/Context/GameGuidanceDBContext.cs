using GameGuidanceAPI.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserFavorite>().ToTable("user_favorites");
        }
    }
}
