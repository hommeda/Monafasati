using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monafasati.Data.Services
{
    public interface IArchiveData
    {
        IEnumerable<Monafsa> GetByStartEndDate(DateTime startDate,DateTime endDate);
    }
}
