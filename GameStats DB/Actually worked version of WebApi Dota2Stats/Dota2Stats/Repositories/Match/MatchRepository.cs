using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Match
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class MatchRepository : IMatchRepository
    {
        ISession session;
        public MatchRepository(ISession session)
        {
            this.session = session;
        }

        public List<Match> GetAll()
        {
            return session.Query<Match>().ToList();
        }

        public Match Get(int id)
        {
            return session.Get<Match>(id);
        }

        public Match Insert(Match model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public Match Update(int id, Match model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<Match>(id);
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
                session.Delete(session.Get<Match>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<Match> GetMatchByDuration(int duration)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.Duration <= duration).ToList();
            }
        }

        public List<Match> GetMatchByDate(DateTime date)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.Date == date).ToList();
            }
        }

        public List<Match> GetMatchByGameMode(string gameMode)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.GameMode == gameMode).ToList();
            }
        }
    }
}