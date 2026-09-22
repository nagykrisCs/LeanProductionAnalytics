using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using static LeanProductionAnalytics.Infrastructure.Common.DbConstants;

namespace LeanProductionAnalytics.Infrastructure.Persistance
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlite($"Data Source={DB_NAME}");

            return new AppDbContext(optionsBuilder.Options);
        }


    }
}
