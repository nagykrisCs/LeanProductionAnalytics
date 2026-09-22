using LeanProductionAnalytics.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeanProductionAnalytics.Infrastructure
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JigExchange>()
                .HasOne(j => j.Production)
                .WithOne(p => p.JigExchange)
                .HasForeignKey<JigExchange>(j => j.ProductionId);

            modelBuilder.Entity<JigExchange>()
                .HasMany(je => je.JigSteps)
                .WithOne(js => js.JigExchange)
                .HasForeignKey(js => js.JigExchangeId);
        }

        public DbSet<Production> Productions { get; set; }
        public DbSet<JigStep> JigStep { get; set; }
        public DbSet<JigExchange> JigExchange { get; set; }
    }
}
