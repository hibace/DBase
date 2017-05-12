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


    public class HeroStatRepository : IHeroStatRepository
    {
        public IEnumerable<HeroStat> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().ToList();
            }
        }

        public HeroStat Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public HeroStat Insert(HeroStat model)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    model.Id = 0;
                    session.Save(model);
                    transaction.Commit();
                }
            }
            return model;
        }

        public HeroStat Update(int id, HeroStat model)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    model.Id = id;
                    session.Update(model);
                    transaction.Commit();
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    HeroStat heroStat = session.Query<HeroStat>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(heroStat);
                    transaction.Commit();
                    return true;
                }
            }
        }
        
        public IEnumerable<HeroStat> GetHeroStatByHeroDamage(int heroDamage)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.HeroDamage >= heroDamage).ToList();
            }
        }

        public IEnumerable<HeroStat> GetHeroStatByHeroHealing(int heroHealing)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.HeroHealing >= heroHealing).ToList();
            }
        }

        public IEnumerable<HeroStat> GetHeroStatByTowerDamage(int towerDamage)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.TowerDamage >= towerDamage).ToList();
            }
        }

        public IEnumerable<HeroStat> GetHeroStatByIdHero(int idHero)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.Hero.Id == idHero).ToList();
            }
        }

        public IEnumerable<HeroStat> GetHeroStatByIdMatch(int idMatch)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<HeroStat>().Where(x => x.Match.Id == idMatch).ToList();
            }
        }
    }
}