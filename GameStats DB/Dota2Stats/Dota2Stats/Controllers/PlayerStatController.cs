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
        private IPlayerStatRepository playerStatRepository;
        public PlayerStatController(IPlayerStatRepository playerStatRepository)
        {
            this.playerStatRepository = playerStatRepository;
        }

        // GET: api/PlayerStat
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerStatRepository.GetAll().Select(o => new PlayerStatResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerStatResource(playerStatRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/PlayerStat
        public HttpResponseMessage Post([FromBody]PlayerStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerStatResource(playerStatRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/PlayerStat/5
        public HttpResponseMessage Put(int id, [FromBody]PlayerStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new PlayerStatResource(playerStatRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/PlayerStat/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                playerStatRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/PlayerStat?idPlayer=100
        public HttpResponseMessage GetPlayerStatByIdPlayer(int idPlayer)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerStatRepository.GetPlayerStatByIdPlayer(idPlayer).Select(o => new PlayerStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/PlayerStat?verified=true
        public HttpResponseMessage GetPlayerStatByVerified(bool verified)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerStatRepository.GetPlayerStatByVerified(verified).Select(o => new PlayerStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/PlayerStat?timeSpentPlaying=1500 (>=)
        public HttpResponseMessage GetPlayerStatByTimeSpentPlaying(int timeSpentPlaying)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerStatRepository.GetPlayerStatByTimeSpentPlaying(timeSpentPlaying).Select(o => new PlayerStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        public HttpResponseMessage GetPlayerStatByMostMatchesPlayed(int mostMatchesPlayed)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, playerStatRepository.GetPlayerStatByMostMatchesPlayed(mostMatchesPlayed).Select(o => new PlayerStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
