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
    using System.Reflection;
    using NHibernate;


    public class MainTempRepository : IMainTempRepository
    {
        ISession session;
        public MainTempRepository(ISession session)
        {
            this.session = session;
        }

        public List<MainTemp> GetAll()
        {
            return session.Query<MainTemp>().ToList();
        }

        public MainTemp Get(int id)
        {
            return session.Get<MainTemp>(id);
        }

        public MainTemp Insert(MainTemp model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public MainTemp Update(int id, MainTemp model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<MainTemp>(id);
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
                session.Delete(session.Get<MainTemp>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<MainTemp> GetMainTempByIdMatch(int idMatch)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Match.Id == idMatch).ToList();
            }
        }

        public List<MainTemp> GetMainTempByIdHero(int idHero)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Hero.Id == idHero).ToList();
            }
        }

        public List<MainTemp> GetMainTempByIdPlayer(int idPlayer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<MainTemp>().Where(x => x.Player.Id == idPlayer).ToList();
            }
        }
    }
}