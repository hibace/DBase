using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class MatchMap : BaseMap<Match>
    {
        protected MatchMap() : base("match", "id")
        {
            Map(x => x.Duration, "duration");
            Map(x => x.Date, "date");
            Map(x => x.GameMode, "game_mode");
        }
    }
}