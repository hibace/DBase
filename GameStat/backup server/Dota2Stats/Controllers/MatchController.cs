using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.Match;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class MatchController : ApiController
    {
        private IMatchRepository matchRepository;
        public MatchController(IMatchRepository matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        // GET: api/Match
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, matchRepository.GetAll().Select(o => new MatchResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new MatchResource(matchRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/Match
        public HttpResponseMessage Post([FromBody]MatchResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MatchResource(matchRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/Match/5
        public HttpResponseMessage Put(int id, [FromBody]MatchResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MatchResource(matchRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/Match/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                matchRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
        

        // Get api/Match?duration=100
        public HttpResponseMessage GetMatchByDuration(int duration)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, matchRepository.GetMatchByDuration(duration).Select(o => new MatchResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/Match?heroHealing=100
        public HttpResponseMessage GetMatchByDate(DateTime date)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, matchRepository.GetMatchByDate(date).Select(o => new MatchResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/Match?gameMode=All Pick
        public HttpResponseMessage GetMatchByGameMode(string gameMode)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, matchRepository.GetMatchByGameMode(gameMode).Select(o => new MatchResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
