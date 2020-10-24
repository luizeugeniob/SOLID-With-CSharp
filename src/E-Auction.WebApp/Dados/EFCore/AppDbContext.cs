using Microsoft.EntityFrameworkCore;
using EAuction.WebApp.Models;

namespace EAuction.WebApp.Dados.EFCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Auctions;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .HasOne(l => l.Category)
                .WithMany(c => c.Auctions)
                .HasForeignKey(l => l.CategoryId);
        }
    }
}