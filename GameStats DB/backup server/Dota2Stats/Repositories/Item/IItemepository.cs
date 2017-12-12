using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Item
{
    using Models;

    public interface IItemRepository : IRepository<Item>
    {
        List<Item> GetItemByName(string name);
        List<Item> GetItemByType(string type);
    }
}