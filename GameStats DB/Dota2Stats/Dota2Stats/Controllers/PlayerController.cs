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
        private IPlayerRepository playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET: api/Player
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerRepository.GetAll().Select(o => new PlayerResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerResource(playerRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/Player
        public HttpResponseMessage Post([FromBody]PlayerResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerResource(playerRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/Player/5
        public HttpResponseMessage Put(int id, [FromBody]PlayerResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerResource(playerRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/Player/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                playerRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/Player?nickName=100
        public HttpResponseMessage GetPlayerByNickName(string nickName)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerRepository.GetPlayerByNickName(nickName).Select(o => new PlayerResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }


        // Get api/Player?numberOfGames=100
        public HttpResponseMessage GetPlayerByNumberOfGames(int numberOfGames)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerRepository.GetPlayerByNumberOfGames(numberOfGames).Select(o => new PlayerResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
