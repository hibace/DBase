using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.MainTemp;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class MainTempController : ApiController
    {
        private IMainTempRepository mainTempRepository;
        public MainTempController(IMainTempRepository mainTempRepository)
        {
            this.mainTempRepository = mainTempRepository;
        }

        // GET: api/MainTemp
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, mainTempRepository.GetAll().Select(o => new MainTempResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new MainTempResource(mainTempRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/MainTemp
        public HttpResponseMessage Post([FromBody]MainTempResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MainTempResource(mainTempRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/MainTemp/5
        public HttpResponseMessage Put(int id, [FromBody]MainTempResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MainTempResource(mainTempRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/MainTemp/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                mainTempRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
        
        // Get api/MainTemp?idMatch=10
        public HttpResponseMessage GetMainTempByIdMatch(int idMatch)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, mainTempRepository.GetMainTempByIdMatch(idMatch).Select(o => new MainTempResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/MainTemp?idHero=1
        public HttpResponseMessage GetMainTempByIdHero(int idHero)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, mainTempRepository.GetMainTempByIdHero(idHero).Select(o => new MainTempResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/MainTemp?idPlayer=5
        public HttpResponseMessage GetMainTempByIdPlayer(int idPlayer)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, mainTempRepository.GetMainTempByIdPlayer(idPlayer).Select(o => new MainTempResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
