using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class HeroMap : BaseMap<Hero>
    {
        protected HeroMap() : base("hero", "id")
        {
            Map(x => x.Name, "name");
            Map(x => x.Hero_class, "hero_class");
            Map(x => x.Role, "role");
            //References(x => x.id_match, "id_match");
        }
    }
}