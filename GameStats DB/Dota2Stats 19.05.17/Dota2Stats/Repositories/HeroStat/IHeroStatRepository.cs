using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.HeroStat
{
    using Models;

    interface IHeroStatRepository : IRepository<HeroStat>
    {
        IEnumerable<HeroStat> GetHeroStatByHeroDamage(int heroDamage);
        IEnumerable<HeroStat> GetHeroStatByHeroHealing(int heroHealing);
        IEnumerable<HeroStat> GetHeroStatByTowerDamage(int towerDamage);
        IEnumerable<HeroStat> GetHeroStatByIdHero(int idHero);
        IEnumerable<HeroStat> GetHeroStatByIdMatch(int idMatch);
    }
}