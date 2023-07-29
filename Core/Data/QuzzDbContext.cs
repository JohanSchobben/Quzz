using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class QuzzDbContext : DbContext
    {
        public QuzzDbContext(DbContextOptions<QuzzDbContext> options) : base(options) { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Round>()
                .Property(x => x.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (RoundType)Enum.Parse(typeof(Round), v));
        }
    }

}
