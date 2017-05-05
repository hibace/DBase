using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories.Hero
{
    using Models;

    interface IHeroRepository : IRepository<Hero>
    {
        IEnumerable<Hero> GetHeroByName(string name);
        IEnumerable<Hero> GetHeroByClass(string hero_class);
        IEnumerable<Hero> GetHeroByRole(string role);
    }
}