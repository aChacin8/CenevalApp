using CenevalApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationDetail> EvaluationDetails { get; set; }

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

            // Relación 1:1 entre User y UserProgress (FK: UserIdInt)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Progress)
                .WithOne(p => p.User)
                .HasForeignKey<UserProgress>(p => p.UserIdInt);

            // Relación 1:N entre User y Evaluations
            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserIdInt);

            // Relación 1:N entre Evaluation y EvaluationDetail
            modelBuilder.Entity<EvaluationDetail>()
                .HasOne(d => d.Evaluation)
                .WithMany(e => e.Details)
                .HasForeignKey(d => d.EvaluationId);

            // Relación EvaluationDetail → Question (sin colección inversa)
            modelBuilder.Entity<EvaluationDetail>()
                .HasOne(d => d.Question)
                .WithMany()
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación EvaluationDetail → Option (la opción seleccionada)
            // Usamos HasNoNavigation para evitar conflictos con Option.Question
            modelBuilder.Entity<EvaluationDetail>()
                .HasOne(d => d.SelectedOption)
                .WithMany()
                .HasForeignKey(d => d.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}