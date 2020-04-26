using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI_SMA.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<int, Item> _itemRepo =
              new ConcurrentDictionary<int, Item>();
       
        public IEnumerable<Item> GetFirstFive()
        {
            return _itemRepo.Values.Take(5);
        }
        public void Add(Item item)
        {
            _itemRepo.TryAdd(item.Id,item);
        }

        public IEnumerable<Item> GetItemAfter(int key)
        {
            var items =  _itemRepo.Values.Skip(key);
            return items.Take(5);
        }
    }
}
