using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.PlayerStat;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class PlayerStatController : ApiController
    {
        PlayerStatRepository playerStatRepository = new PlayerStatRepository();

        // GET: api/PlayerStat
        public HttpResponseMessage Get()
        {
            List<PlayerStat> items;
            try
            {
                items = playerStatRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<IEnumerable<PlayerStat>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            PlayerStat item;
            try
            {
                item = new PlayerStatResource(playerStatRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<PlayerStat>(HttpStatusCode.OK, item);
        }

        //POST api/PlayerStat
        public HttpResponseMessage Post([FromBody]PlayerStatResource value)
        {
            try
            {
                value = new PlayerStatResource(playerStatRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<PlayerStatResource>(HttpStatusCode.OK, value);
        }

        //PUT api/PlayerStat/5
        public HttpResponseMessage Put(int id, [FromBody]PlayerStatResource value)
        {
            try
            {
                value = new PlayerStatResource(playerStatRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<PlayerStatResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/PlayerStat/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                playerStatRepository.Delete(id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// ////
        /// </summary>
        /// 

        // Get api/PlayerStat?idPlayer=100
        public HttpResponseMessage GetPlayerStatByIdPlayer(int idPlayer)
        {
            List<PlayerStat> items;
            try
            {
                items = playerStatRepository.GetPlayerStatByIdPlayer(idPlayer).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<PlayerStat>>(HttpStatusCode.OK, items);
        }

        // Get api/PlayerStat?verified=true
        public HttpResponseMessage GetPlayerStatByVerified(bool verified)
        {
            List<PlayerStat> items;
            try
            {
                items = playerStatRepository.GetPlayerStatByVerified(verified).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<PlayerStat>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying)
        {
            List<PlayerStat> items;
            try
            {
                items = playerStatRepository.GetPlayerStatByTimeSpentPlaying(timeSpentPlaying).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<PlayerStat>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed)
        {
            List<PlayerStat> items;
            try
            {
                items = playerStatRepository.GetPlayerStatByMostMatchesPlayed(mostMatchesPlayed).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<PlayerStat>>(HttpStatusCode.OK, items);
        }
    }
}
