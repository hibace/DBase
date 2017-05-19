using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.MainTemp
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;


    public class MainTempRepository : IMainTempRepository
    {
        public IEnumerable<MainTemp> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().ToList();
            }
        }

        public MainTemp Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public MainTemp Insert(MainTemp model)
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

        public MainTemp Update(int id, MainTemp model)
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
                    MainTemp mainTemp = session.Query<MainTemp>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(mainTemp);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<MainTemp> GetMainTempByIdMatch(int idMatch)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Match.Id == idMatch).ToList();
            }
        }

        public IEnumerable<MainTemp> GetMainTempByIdHero(int idHero)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Hero.Id == idHero).ToList();
            }
        }

        public IEnumerable<MainTemp> GetMainTempByIdPlayer(int idPlayer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Player.Id == idPlayer).ToList();
            }
        }
    }
}