using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Player
{
    using Models;

    interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetPlayerByNickName(string nickName);
        IEnumerable<Player> GetPlayerByNumberOfGames(int numberOfGames);
    }
}