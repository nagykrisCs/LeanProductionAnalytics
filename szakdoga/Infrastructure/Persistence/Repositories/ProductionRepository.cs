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


        public void InsertProductionRow(Production productionRow)
        {
            _dbcontext.Add(productionRow);
            _dbcontext.SaveChanges();
        }
        public void ReadProductionTable()
        {
            foreach (var row in _dbcontext.Productions.ToList())
                Console.WriteLine($"Id: {row.Id}");
        }
    }
}
