using GameGuidanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameGuidanceAPI.Context
{
    public class GameGuidanceDBContext : DbContext
    {
        public GameGuidanceDBContext(DbContextOptions<GameGuidanceDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<UserIgnore> UserIgnores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<UserFavorite>().ToTable("userFavorites");
            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Choice>().ToTable("choices");
            modelBuilder.Entity<UserIgnore>().ToTable("userIgnores");
        }
    }
}