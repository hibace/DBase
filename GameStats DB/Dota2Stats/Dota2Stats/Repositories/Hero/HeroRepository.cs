using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Hero
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;


    public class HeroRepository : IHeroRepository
    {
        public IEnumerable<Hero> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Hero>().ToList();
            }
        }

        public Hero Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Hero>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public Hero Insert(Hero model)
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

        public Hero Update(int id, Hero model)
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
                    Hero hero = session.Query<Hero>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(hero);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<Hero> GetHeroByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Hero>().Where(x => x.Name == name).ToList();
            }
        }

        public IEnumerable<Hero> GetHeroByClass(string hero_class)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Hero>().Where(x => x.Hero_class == hero_class).ToList();
            }
        }

        public IEnumerable<Hero> GetHeroByRole(string role)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Hero>().Where(x => x.Role == role).ToList();
            }
        }
    }
}