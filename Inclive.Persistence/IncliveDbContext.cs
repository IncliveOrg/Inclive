using Inclive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inclive.Persistence
{
    public class IncliveDbContext : DbContext
    {
        public IncliveDbContext(DbContextOptions<IncliveDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IncliveDbContext).Assembly);
        }

        public DbSet<Player> Players { get; set; }
    }
}