using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.ItemStat
{
    using Models;

    public interface IItemStatRepository : IRepository<ItemStat>
    {
        List<ItemStat> GetItemStatByTimeUsed(int timeUsed);
        List<ItemStat> GetItemStatByIdItem(int idItem);
    }
}