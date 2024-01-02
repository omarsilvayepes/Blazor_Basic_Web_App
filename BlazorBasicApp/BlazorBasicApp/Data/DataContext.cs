using BlazorBasicApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorBasicApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        // set some data(seed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "SuperMario" },
                new Game { Id = 2, Name = "Pro Evolution Soccer 6" },
                new Game { Id = 3, Name = "Call of Duty" }
                );
        }
    }
}
