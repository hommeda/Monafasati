using Monafasati.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monafasati.Data.Services
{
    public interface IEngineerData
    {
        IEnumerable<Engineer> GetAll();
    }
}
