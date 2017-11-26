using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.PlayerStat
{
    using Models;

    public interface IPlayerStatRepository : IRepository<PlayerStat>
    {
        List<PlayerStat> GetPlayerStatByIdPlayer(int idPlayer);
        List<PlayerStat> GetPlayerStatByVerified(bool verified);
        List<PlayerStat> GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying);
        List<PlayerStat> GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed);
    }
}