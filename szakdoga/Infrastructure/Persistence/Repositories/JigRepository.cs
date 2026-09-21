using LeanProductionAnalytics.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanProductionAnalytics.Infrastructure.Persistence.Repositories
{
    public class JigRepository
    {
        private readonly AppDbContext _dbcontext;

        internal JigRepository(AppDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public void InsertJigRow(Jig jigRow)
        {
            _dbcontext.Add(jigRow);
            _dbcontext.SaveChanges();
        }

        public void ReadJigTable()
        {
            foreach (var row in _dbcontext.Jigs.ToList())
                Console.WriteLine($"Id: {row.Id}");
        }
    }
}
