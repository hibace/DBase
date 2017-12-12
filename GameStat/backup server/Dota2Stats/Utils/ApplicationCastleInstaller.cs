using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Dota2Stats.Utils
{
    using Repositories.Hero;
    using Repositories.HeroStat;
    using Repositories.Item;
    using Repositories.ItemStat;
    using Repositories.ItemTemp;
    using Repositories.MainTemp;
    using Repositories.Match;
    using Repositories.Player;
    using Repositories.PlayerStat;
    using Controllers;
    using Middleware;

    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISession>().UsingFactoryMethod(NHibernateHelper.OpenSession).LifestylePerWebRequest());

            container.Register(Component.For<IHeroRepository>().ImplementedBy<HeroRepository>().LifestyleTransient());
            container.Register(Component.For<IHeroStatRepository>().ImplementedBy<HeroStatRepository>().LifestyleTransient());
            container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>().LifestyleTransient());
            container.Register(Component.For<IItemStatRepository>().ImplementedBy<ItemStatRepository>().LifestyleTransient());
            container.Register(Component.For<IItemTempRepository>().ImplementedBy<ItemTempRepository>().LifestyleTransient());
            container.Register(Component.For<IMainTempRepository>().ImplementedBy<MainTempRepository>().LifestyleTransient());
            container.Register(Component.For<IMatchRepository>().ImplementedBy<MatchRepository>().LifestyleTransient());
            container.Register(Component.For<IPlayerRepository>().ImplementedBy<PlayerRepository>().LifestyleTransient());
            container.Register(Component.For<IPlayerStatRepository>().ImplementedBy<PlayerStatRepository>().LifestyleTransient());


            var controllers = Assembly.GetExecutingAssembly()
                .GetTypes().Where(x => x.BaseType == typeof(ApiController)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}