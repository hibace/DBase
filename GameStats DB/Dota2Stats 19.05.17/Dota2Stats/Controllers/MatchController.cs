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
        MatchRepository matchRepository = new MatchRepository();

        // GET: api/Match
        public HttpResponseMessage Get()
        {
            List<Match> items;
            try
            {
                items = matchRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MatchResource(items[i]).ToModel();
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
            return Request.CreateResponse<IEnumerable<Match>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            Match item;
            try
            {
                item = new MatchResource(matchRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<Match>(HttpStatusCode.OK, item);
        }

        //POST api/Match
        public HttpResponseMessage Post([FromBody]MatchResource value)
        {
            try
            {
                value = new MatchResource(matchRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<MatchResource>(HttpStatusCode.OK, value);
        }

        //PUT api/Match/5
        public HttpResponseMessage Put(int id, [FromBody]MatchResource value)
        {
            try
            {
                value = new MatchResource(matchRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<MatchResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/Match/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                matchRepository.Delete(id);
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

        // Get api/Match?duration=100
        public HttpResponseMessage GetMatchByDuration(int duration)
        {
            List<Match> items;
            try
            {
                items = matchRepository.GetMatchByDuration(duration).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MatchResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Match>>(HttpStatusCode.OK, items);
        }

        // Get api/Match?heroHealing=100
        public HttpResponseMessage GetMatchByDate(DateTime date)
        {
            List<Match> items;
            try
            {
                items = matchRepository.GetMatchByDate(date).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MatchResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Match>>(HttpStatusCode.OK, items);
        }

        // Get api/Match?gameMode=All Pick
        public HttpResponseMessage GetMatchByGameMode(string gameMode)
        {
            List<Match> items;
            try
            {
                items = matchRepository.GetMatchByGameMode(gameMode).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MatchResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Match>>(HttpStatusCode.OK, items);
        }
    }
}
