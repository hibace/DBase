using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ItemStatMap : BaseMap<ItemStat>
    {
        protected ItemStatMap() : base("item_stat", "id")
        {
            References(x => x.Item, "id_item");
            Map(x => x.TimeUsed, "time_used");
        }
    }
}