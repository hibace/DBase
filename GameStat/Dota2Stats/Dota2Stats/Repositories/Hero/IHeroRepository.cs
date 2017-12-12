using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Hero
{
    using Models;

    public interface IHeroRepository : IRepository<Hero>
    {
        List<Hero> GetHeroByName(string name);
        List<Hero> GetHeroByClass(string heroClass);
        List<Hero> GetHeroByRole(string role);
    }
}