using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.PlayerStat
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class PlayerStatRepository : IPlayerStatRepository
    {
        ISession session;
        public PlayerStatRepository(ISession session)
        {
            this.session = session;
        }

        public List<PlayerStat> GetAll()
        {
            return session.Query<PlayerStat>().ToList();
        }

        public PlayerStat Get(int id)
        {
            return session.Get<PlayerStat>(id);
            //return session.Query<PlayerStat>().Where(x => x.Id == id).SingleOrDefault();
        }

        public PlayerStat Insert(PlayerStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public PlayerStat Update(int id, PlayerStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<PlayerStat>(id);
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
                session.Delete(session.Get<PlayerStat>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<PlayerStat> GetPlayerStatByIdPlayer(int idPlayer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.Player.Id == idPlayer).ToList();
            }
        }

        public List<PlayerStat> GetPlayerStatByVerified(bool verified)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.Verified == verified).ToList();
            }
        }

        public List<PlayerStat> GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.TimeSpentPlaying >= timeSpentPlaying).ToList();
            }
        }

        public List<PlayerStat> GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.MostMatchesPlayed >= mostMatchesPlayed).ToList();
            }
        }
    }
}