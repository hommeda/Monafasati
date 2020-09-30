using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Monafasati.Data.Services
{
    public class MonafasaData : IMonafasaData
    {
        private readonly MonafasatiDbContext db;

        public MonafasaData(MonafasatiDbContext Db)
        {
            db = Db;
        }

        public async Task<Monafsa> Edit(int? Id)
        {

            if (Id == null)
            {
                return null;
            }

            var monafsa = await db.Monafsas.FindAsync(Id);
            if (monafsa == null)
            {
                return null;
            }
            return monafsa;
        }

        public IEnumerable<Monafsa> GetAll()
        {
            return db.Monafsas
                .Include(c => c.Statu)
                .Include(c => c.Engineer)
                .ToList();
        }

        public IEnumerable<Monafsa> GetByEngineer(int EngineerId)
        {
            var MonafasaModel = db.Monafsas
    .Include(c => c.Statu)
    .Include(c => c.Engineer)
    .Where(c => c.EngineerId == EngineerId)
    .Where(c=>c.LastDate>=DateTime.Now.AddDays(1))
    .ToList();
            return MonafasaModel;
        }

        public IEnumerable<Monafsa> GetByPeriodTime(DateTime startDtae,DateTime endDate)
        {
            var MonafsatOfMonth = db.Monafsas
                .Include(c => c.Statu)
                .Include(c => c.Engineer)
                .Where(c=>c.LastDate>=startDtae)
                .Where(c=>c.LastDate<=endDate)
                .ToList();
            return MonafsatOfMonth;

        }

        public IEnumerable<Monafsa> GetByStatu(int StatuId)
        {
           


            var MonafasaModel = db.Monafsas
                .Include(c => c.Statu)
                .Include(c => c.Engineer)
                .Where(c => c.StatuId == StatuId)
                .Where(c => c.LastDate >= DateTime.Now)
                   .OrderByDescending(c => c.LastDate).ToList();
            var dat = db.Monafsas.SingleOrDefault(m => m.Id == 10).LastDate;

            //
            foreach (var m in MonafasaModel)
            {
                string v = m.LastDate.ToShortDateString();
                m.LastDate = DateTime.Parse(v);
            }
            MonafasaModel.OrderBy(c => c.LastDate);
//

            return MonafasaModel;
        }
        public Monafsa GetMonafasDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var monafsa = db.Monafsas
                .Include(m => m.Engineer)
                .Include(m => m.Statu)
                .FirstOrDefault(m => m.Id == id);
            if (monafsa == null)
            {
                return null;
            }

            return monafsa;
        }
        private bool MonafsaExists(int id)
        {
            return db.Monafsas.Any(e => e.Id == id);
        }
    }
}
