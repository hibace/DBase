using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Player
{
    using Models;

    public interface IPlayerRepository : IRepository<Player>
    {
        List<Player> GetPlayerByNickName(string nickName);
        List<Player> GetPlayerByNumberOfGames(int numberOfGames);
    }
}