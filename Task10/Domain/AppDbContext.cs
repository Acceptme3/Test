using Microsoft.EntityFrameworkCore;
using Task10.Domain.Entities;

namespace Task10.Domain
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Investment>().HasData(new Investment() { CountMonth = 0, Deposit = 0, TotalDeposit = 0 });
        }
    }
}
