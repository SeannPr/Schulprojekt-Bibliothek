using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Schulprojekt_Bibliothek.DCF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Buch> Buche { get; set; }
        public DbSet<Ausleihungen> Ausleihungen { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbPath = @"C:\Users\benbe\source\repos\Schulprojekt-Bibliothek\Schulprojekt-Bibliothek\db\buch.db";
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ausleihungen>()
                .HasOne(a => a.User)
                .WithMany(u => u.Ausleihungen)
                .HasForeignKey(a => a.Userld);
        }
    }
}
