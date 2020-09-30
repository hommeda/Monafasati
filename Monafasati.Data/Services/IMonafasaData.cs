using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monafasati.Data.Services
{
    public interface IMonafasaData
    {
        IEnumerable<Monafsa> GetAll();
        IEnumerable<Monafsa> GetByStatu(int StatuId);
        IEnumerable<Monafsa> GetByEngineer(int StatuId);
        Monafsa GetMonafasDetails(int? id);
        Task<Monafsa> Edit(int? Id);
        IEnumerable<Monafsa> GetByPeriodTime(DateTime startDtae, DateTime endDate);
    }
}
