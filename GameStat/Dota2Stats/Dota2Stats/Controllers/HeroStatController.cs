using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.HeroStat;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class HeroStatController : ApiController
    {
        private IHeroStatRepository heroStatRepository;
        public HeroStatController(IHeroStatRepository heroStatRepository)
        {
            this.heroStatRepository = heroStatRepository;
        }

        // GET: api/HeroStat
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroStatRepository.GetAll().Select(o => new HeroStatResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new HeroStatResource(heroStatRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/HeroStat
        public HttpResponseMessage Post([FromBody]HeroStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new HeroStatResource(heroStatRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/HeroStat/5
        public HttpResponseMessage Put(int id, [FromBody]HeroStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new HeroStatResource(heroStatRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/HeroStat/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                heroStatRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/HeroStat?heroDamage=100
        public HttpResponseMessage GetHeroStatByHeroDamage(int heroDamage)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroStatRepository.GetHeroStatByHeroDamage(heroDamage).Select(o => new HeroStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/hero?heroHealing=100
        public HttpResponseMessage GetHeroStatByHeroHealing(int heroHealing)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroStatRepository.GetHeroStatByHeroHealing(heroHealing).Select(o => new HeroStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/hero?towerDamage=500
        public HttpResponseMessage GetHeroStatByTowerDamage(int towerDamage)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroStatRepository.GetHeroStatByTowerDamage(towerDamage).Select(o => new HeroStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
