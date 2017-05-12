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


    public class PlayerStatRepository : IPlayerStatRepository
    {
        public IEnumerable<PlayerStat> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().ToList();
            }
        }

        public PlayerStat Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public PlayerStat Insert(PlayerStat model)
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

        public PlayerStat Update(int id, PlayerStat model)
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
                    PlayerStat playerStat = session.Query<PlayerStat>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(playerStat);
                    transaction.Commit();
                    return true;
                }
            }
        }
        
        public IEnumerable<PlayerStat> GetPlayerStatByIdPlayer(int idPlayer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.Player.Id == idPlayer).ToList();
            }
        }

        public IEnumerable<PlayerStat> GetPlayerStatByVerified(bool verified)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.Verified == verified).ToList();
            }
        }

        public IEnumerable<PlayerStat> GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.TimeSpentPlaying >= timeSpentPlaying).ToList();
            }
        }

        public IEnumerable<PlayerStat> GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<PlayerStat>().Where(x => x.MostMatchesPlayed >= mostMatchesPlayed).ToList();
            }
        }
    }
}