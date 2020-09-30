using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monafasati.Data.Services
{
    public class EngineerData : IEngineerData
    {
        private readonly MonafasatiDbContext db;

        public EngineerData(MonafasatiDbContext Db)
        {
            db = Db;
        }
        public IEnumerable<Engineer> GetAll()
        {
            return db.Engineers.ToList();
        }
    }
}
