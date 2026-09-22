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

        // Method to insert a row of Jig
        public void InsertJigRow(JigStep jigRow)
        {
            _dbcontext.Add(jigRow);
            _dbcontext.SaveChanges();
        }

        // Method to insert an entire table of Jig
        public void InsertJigTable(IEnumerable<JigStep> jigs)
        {
            foreach (var jig in jigs)
            {
                _dbcontext.Add(jig);
            }
            
            _dbcontext.SaveChanges();
        }

        // Method to read ID of Jig database - debugging purposes
        //public void ReadJigTable()
        //{
        //    foreach (var row in _dbcontext.Jigs.ToList())
        //        Console.WriteLine($"Id: {row.Id}");
        //}
    }
}
