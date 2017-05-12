using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Player
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;


    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().ToList();
            }
        }

        public Player Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public Player Insert(Player model)
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

        public Player Update(int id, Player model)
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
                    Player player = session.Query<Player>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(player);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<Player> GetPlayerByNickName(string nickName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().Where(x => x.Nickname == nickName).ToList();
            }
        }

        public IEnumerable<Player> GetPlayerByNumberOfGames(int numberOfGames)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().Where(x => x.NumberOfGames >= numberOfGames).ToList();
            }
        }
    }
}