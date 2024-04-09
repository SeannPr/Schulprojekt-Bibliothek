using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Schulprojekt_Bibliothek.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }            // DbSet for Users table
        public DbSet<Ausleihungen> Ausleihungen { get; set; }  // DbSet for Ausleihungen table
        public DbSet<Buch> Bücher { get; set; }          // DbSet for Bücher table

        // Constructor
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // Define the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<User>().HasKey(u => u.id);
            modelBuilder.Entity<Ausleihungen>().HasKey(a => a.id);
            modelBuilder.Entity<Buch>().HasKey(b => b.id);

            // Define foreign keys
            modelBuilder.Entity<Ausleihungen>().HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.Userld);
        }

    }
}


