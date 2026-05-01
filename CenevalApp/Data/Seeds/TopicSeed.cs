using Microsoft.EntityFrameworkCore;
using CenevalApp.Models;

namespace CenevalApp.Data.Seeds
{
    public static class TopicSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = 1, Name = "Ingeniería de Software" },
                new Topic { TopicId = 2, Name = "Bases de Datos" }
            );
        }
    }
}