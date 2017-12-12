using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.HeroStat
{
    using Models;

    public interface IHeroStatRepository : IRepository<HeroStat>
    {
        List<HeroStat> GetHeroStatByHeroDamage(int heroDamage);
        List<HeroStat> GetHeroStatByHeroHealing(int heroHealing);
        List<HeroStat> GetHeroStatByTowerDamage(int towerDamage);
        List<HeroStat> GetHeroStatByIdHero(int idHero);
        List<HeroStat> GetHeroStatByIdMatch(int idMatch);
    }
}