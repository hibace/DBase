using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Match
{
    using Models;

    public interface IMatchRepository : IRepository<Match>
    {
        List<Match> GetMatchByDuration(int duration);
        List<Match> GetMatchByDate(DateTime date);
        List<Match> GetMatchByGameMode(string gameMode);
    }
}