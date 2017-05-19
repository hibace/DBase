using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class PlayerMap : BaseMap<Player>
    {
        protected PlayerMap() : base("player", "id")
        {
            Map(x => x.Nickname, "nickname");
            Map(x => x.NumberOfGames, "number_of_games");
        }
    }
}