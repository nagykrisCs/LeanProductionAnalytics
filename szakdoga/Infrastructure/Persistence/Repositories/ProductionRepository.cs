using LeanProductionAnalytics.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanProductionAnalytics.Infrastructure.Persistence.Repositories
{
    public class ProductionRepository
    {
        private readonly AppDbContext _dbcontext;

        internal ProductionRepository(AppDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        // Method to insert a row of Production
        public void InsertProductionRow(Production productionRow)
        {
            _dbcontext.Add(productionRow);
            _dbcontext.SaveChanges();
        }

        // Method to insert an entire table of Production
        public void InsertProductionTable(IEnumerable<Production> productionRows)
        {
            foreach (var row in productionRows)
            {
                _dbcontext.Add(row);
            }

            _dbcontext.SaveChanges();
        }

        // Method to read the Production database - debugging purposes
        public void ReadProductionTable()
        {
            foreach (var row in _dbcontext.Productions.ToList())
            {
                Console.WriteLine($"Id: {row.Id}");
            } 
        }
    }
}
