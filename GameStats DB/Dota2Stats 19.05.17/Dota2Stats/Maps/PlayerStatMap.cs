using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class PlayerStatMap : BaseMap<PlayerStat>
    {
        protected PlayerStatMap() : base("player_stat", "id")
        {
            Map(x => x.Verified, "verified");
            Map(x => x.TimeSpentPlaying, "time_spent_playing");
            Map(x => x.MostMatchesPlayed, "most_matches_played");
            References(x => x.Player, "id_player");
        }
    }
}