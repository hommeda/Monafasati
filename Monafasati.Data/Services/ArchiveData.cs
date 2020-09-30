using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monafasati.Data.Services
{
    public class ArchiveData : IArchiveData
    {
        private readonly MonafasatiDbContext db;

        public ArchiveData(MonafasatiDbContext Db )
        {
            db = Db;
        }
        public IEnumerable<Monafsa> GetByStartEndDate(DateTime startDate, DateTime endDate)
        {
            
            var Monafsas = db.Monafsas
                .Where(c => c.LastDate >= startDate)
                .Where(c=>c.LastDate<=startDate.AddMonths(1))
                .Include(c=>c.Engineer)
                .Include(c=>c.Statu)
                .ToList();
            return Monafsas;
        }
    }
}
