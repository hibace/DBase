using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Match
{
    using Models;

    interface IMatchRepository : IRepository<Match>
    {
        IEnumerable<Match> GetMatchByDuration(int duration);
        IEnumerable<Match> GetMatchByDate(DateTime date);
        IEnumerable<Match> GetMatchByGameMode(string gameMode);
    }
}