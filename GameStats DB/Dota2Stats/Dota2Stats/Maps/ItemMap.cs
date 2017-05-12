using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ItemMap : BaseMap<Item>
    {
        protected ItemMap() : base("item", "id")
        {
            Map(x => x.Name, "name");
            Map(x => x.Type, "type");
        }
    }
}