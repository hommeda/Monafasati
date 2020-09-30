using Microsoft.EntityFrameworkCore;
using Monafasati.Core.Entity;
using Monafasati.Data.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monafasati.Data.Services
{
    public class ItemData : IItemData
    {
        private readonly MonafasatiDbContext db;

        public ItemData(MonafasatiDbContext Db)
        {
            db = Db;
        }

        public bool Create(ItemDto item)
        {
            var Item = new Item()
            {
                ItemCode = item.ItemCode,
                BuyPrice=item.BuyPrice,
                Count=item.Count,
                Monafsa=item.Monafsa,
                MonafsaId=item.MonafsaId,
                Name=item.Name,
                Notes=item.Notes,
                Price=item.Price,
                Units=item.Units,
                UnitsId=item.UnitsId

            };
            db.Items.Add(Item);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Item> GetItemsByMonafsaId(int monafsaId)
        {
            var MonafasaItemModel = db.Items
                 .Include(c=>c.Monafsa)
                 .Include(c => c.Units)
                 .Where(c=>c.MonafsaId==monafsaId)
                 .ToList();
           
            return MonafasaItemModel;
            
        }
    }
}
