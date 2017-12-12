using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ItemTempMap : BaseMap<ItemTemp>
    {
        protected ItemTempMap() : base("itemtemp", "id")
        {
            References(x => x.MainTemp, "id_maintemp");
            References(x => x.Item, "id_item");
        }
    }
}