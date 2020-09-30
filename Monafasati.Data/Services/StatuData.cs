using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monafasati.Data.Services
{
    public class StatuData : IStatuData
    {
        private readonly MonafasatiDbContext db;

        public StatuData(MonafasatiDbContext Db)
        {
            db = Db;
        }
        public IEnumerable<Statu> GetAll()
        {
            return db.Status.ToList();
        }
    }
}
