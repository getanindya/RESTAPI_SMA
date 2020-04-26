using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI_SMA.Models
{
    public interface IItemRepository
    {
        void Add(Item item);
        IEnumerable<Item> GetFirstFive();
        IEnumerable<Item> GetItemAfter(int key);
       
    }
}
