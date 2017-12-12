using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class HeroStatMap : BaseMap<HeroStat>
    {
        protected HeroStatMap() : base("hero_stat", "id")
        {
            Map(x => x.HeroDamage, "hero_damage");
            Map(x => x.HeroHealing, "hero_healing");
            Map(x => x.TowerDamage, "tower_damage");
            References(x => x.Hero, "id_hero");
            References(x => x.Match, "id_match");
        }
    }
}