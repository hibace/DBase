using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.HeroStat
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class HeroStatRepository : IHeroStatRepository
    {
        ISession session;
        public HeroStatRepository(ISession session)
        {
            this.session = session;
        }

        public List<HeroStat> GetAll()
        {
            return session.Query<HeroStat>().ToList();
        }

        public HeroStat Get(int id)
        {
            return session.Get<HeroStat>(id);
        }

        public HeroStat Insert(HeroStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public HeroStat Update(int id, HeroStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<HeroStat>(id);
                foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.Name != "Id"))
                {
                    property.SetValue(item, property.GetValue(model));
                }
                session.Update(item);
                transaction.Commit();
                return item;
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(session.Get<HeroStat>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<HeroStat> GetHeroStatByHeroDamage(int heroDamage)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.HeroDamage >= heroDamage).ToList();
            }
        }

        public List<HeroStat> GetHeroStatByHeroHealing(int heroHealing)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.HeroHealing >= heroHealing).ToList(); 
            }
        }

        public List<HeroStat> GetHeroStatByTowerDamage(int towerDamage)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.TowerDamage >= towerDamage).ToList(); 
            }
        }

        public List<HeroStat> GetHeroStatByIdHero(int idHero)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.Hero.Id == idHero).ToList();
            }
        }

        public List<HeroStat> GetHeroStatByIdMatch(int idMatch)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.Match.Id == idMatch).ToList();
            }
        }
    }
}