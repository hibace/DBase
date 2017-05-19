using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Item
{
    using Models;

    interface IItemRepository : IRepository<Item>
    {
        IEnumerable<Item> GetItemByName(string name);
        IEnumerable<Item> GetItemByType(string type);
    }
}