using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.Player;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class PlayerController : ApiController
    {
        PlayerRepository playerRepository = new PlayerRepository();

        // GET: api/Player
        public HttpResponseMessage Get()
        {
            List<Player> items;
            try
            {
                items = playerRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerResource(items[i]).ToModel();
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
            return Request.CreateResponse<IEnumerable<Player>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            Player item;
            try
            {
                item = new PlayerResource(playerRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<Player>(HttpStatusCode.OK, item);
        }

        //POST api/Player
        public HttpResponseMessage Post([FromBody]PlayerResource value)
        {
            try
            {
                value = new PlayerResource(playerRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<PlayerResource>(HttpStatusCode.OK, value);
        }

        //PUT api/Player/5
        public HttpResponseMessage Put(int id, [FromBody]PlayerResource value)
        {
            try
            {
                value = new PlayerResource(playerRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<PlayerResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/Player/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                playerRepository.Delete(id);
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

        // Get api/Player?nickName=100
        public HttpResponseMessage GetPlayerByNickName(string nickName)
        {
            List<Player> items;
            try
            {
                items = playerRepository.GetPlayerByNickName(nickName).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Player>>(HttpStatusCode.OK, items);
        }

        // Get api/Player?numberOfGames=100
        public HttpResponseMessage GetPlayerByNumberOfGames(int numberOfGames)
        {
            List<Player> items;
            try
            {
                items = playerRepository.GetPlayerByNumberOfGames(numberOfGames).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new PlayerResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Player>>(HttpStatusCode.OK, items);
        }
    }
}
