using CenevalApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CenevalApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación 1:N entre Topic y Question
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId);

            // Relación 1:N entre Question y Option
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId);

            modelBuilder.Entity<User>()
            .HasOne(u => u.Progress)
            .WithOne()
            .HasForeignKey<UserProgress>(p => p.UserId);

            // Ejecución de Semillas (Seeding)
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Data.Seeds.TopicSeed.Seed(modelBuilder);
            Data.Seeds.QuestionSeed.Seed(modelBuilder);
            Data.Seeds.OptionSeed.Seed(modelBuilder);
        }
    }
}