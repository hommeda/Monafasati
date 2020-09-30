using Monafasati.Core.Entity;
using Monafasati.Data.ModelDto;
using System;
using System.Collections.Generic;
using System.Text;


namespace Monafasati.Data.Services
{
    public interface IItemData
    {
        IEnumerable<Item> GetItemsByMonafsaId(int monafsaId);
        bool Create(ItemDto item);
    }
}
