using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.MainTemp
{
    using Models;

    interface IMainTempRepository : IRepository<MainTemp>
    {
        IEnumerable<MainTemp> GetMainTempByIdMatch(int idMatch);
        IEnumerable<MainTemp> GetMainTempByIdHero(int idHero);
        IEnumerable<MainTemp> GetMainTempByIdPlayer(int idPlayer);
    }
}