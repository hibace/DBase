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


    public class MatchRepository : IMatchRepository
    {
        public IEnumerable<Match> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().ToList();
            }
        }

        public Match Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public Match Insert(Match model)
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

        public Match Update(int id, Match model)
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
                    Match match = session.Query<Match>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(match);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<Match> GetMatchByDuration(int duration)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.Duration <= duration).ToList();
            }
        }

        public IEnumerable<Match> GetMatchByDate(DateTime date)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.Date == date).ToList();
            }
        }

        public IEnumerable<Match> GetMatchByGameMode(string gameMode)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Match>().Where(x => x.GameMode == gameMode).ToList();
            }
        }
    }
}