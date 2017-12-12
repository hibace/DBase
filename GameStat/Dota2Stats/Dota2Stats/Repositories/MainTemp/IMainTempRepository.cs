using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.MainTemp
{
    using Models;

    public interface IMainTempRepository : IRepository<MainTemp>
    {
        List<MainTemp> GetMainTempByIdMatch(int idMatch);
        List<MainTemp> GetMainTempByIdHero(int idHero);
        List<MainTemp> GetMainTempByIdPlayer(int idPlayer);
    }
}