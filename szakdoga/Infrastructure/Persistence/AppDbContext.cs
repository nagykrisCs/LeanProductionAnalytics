using LeanProductionAnalytics.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeanProductionAnalytics.Infrastructure
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Jig> Jigs { get; set; }
    }
}
