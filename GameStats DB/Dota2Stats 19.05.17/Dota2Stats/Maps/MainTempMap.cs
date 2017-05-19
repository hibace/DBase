using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class MainTempMap : BaseMap<MainTemp>
    {
        protected MainTempMap() : base("maintemp", "id")
        {
            References(x => x.Player, "id_player");
            References(x => x.Hero, "id_hero");
            References(x => x.Match, "id_match");
        }
    }
}