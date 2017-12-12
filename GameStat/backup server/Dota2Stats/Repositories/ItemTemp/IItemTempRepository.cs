using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.ItemTemp
{
    using Models;

    public interface IItemTempRepository : IRepository<ItemTemp>
    {
        List<ItemTemp> GetItemTempByIdMainTemp(int idMainTemp);
        List<ItemTemp> GetItemTempByIdItem(int idItem);
    }
}