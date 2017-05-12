using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.ItemTemp
{
    using Models;

    interface IItemTempRepository : IRepository<ItemTemp>
    {
        IEnumerable<ItemTemp> GetItemTempByIdMainTemp(int idMainTemp);
        IEnumerable<ItemTemp> GetItemTempByIdItem(int idItem);
    }
}