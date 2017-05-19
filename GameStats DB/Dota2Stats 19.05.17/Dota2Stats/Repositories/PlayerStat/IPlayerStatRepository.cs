using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.PlayerStat
{
    using Models;

    interface IPlayerStatRepository : IRepository<PlayerStat>
    {
        IEnumerable<PlayerStat> GetPlayerStatByIdPlayer(int idPlayer);
        IEnumerable<PlayerStat> GetPlayerStatByVerified(bool verified);
        IEnumerable<PlayerStat> GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying);
        IEnumerable<PlayerStat> GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed);
    }
}