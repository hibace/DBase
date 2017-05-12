using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.ItemStat
{
    using Models;

    interface IItemStatRepository : IRepository<ItemStat>
    {
        IEnumerable<ItemStat> GetItemStatByTimeUsed(int timeUsed);
        IEnumerable<ItemStat> GetItemStatByIdItem(int idItem);
    }
}