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
        HeroStatRepository heroStatRepository = new HeroStatRepository();

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

            //List<HeroStat> items;
            //try
            //{
            //    items = heroStatRepository.GetAll().ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroStatResource(items[i]).ToModel();
            //    }
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<IEnumerable<HeroStat>>(HttpStatusCode.OK, items);
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

            //HeroStat item;
            //try
            //{
            //    item = new HeroStatResource(heroStatRepository.Get(id)).ToModel();
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<HeroStat>(HttpStatusCode.OK, item);
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

            //try
            //{
            //    value = new HeroStatResource(heroStatRepository.Insert(value.ToModel()));
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<HeroStatResource>(HttpStatusCode.OK, value);
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

            //try
            //{
            //    value = new HeroStatResource(heroStatRepository.Update(id, value.ToModel()));
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<HeroStatResource>(HttpStatusCode.OK, value);
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

            //try
            //{
            //    heroStatRepository.Delete(id);
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// ////
        /// </summary>

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

            //List<HeroStat> items;
            //try
            //{
            //    items = heroStatRepository.GetHeroStatByHeroDamage(heroDamage).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroStatResource(items[i]).ToModel();
            //    }
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<List<HeroStat>>(HttpStatusCode.OK, items);
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

            //List<HeroStat> items;
            //try
            //{
            //    items = heroStatRepository.GetHeroStatByHeroHealing(heroHealing).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroStatResource(items[i]).ToModel();
            //    }
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<List<HeroStat>>(HttpStatusCode.OK, items);
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

            //List<HeroStat> items;
            //try
            //{
            //    items = heroStatRepository.GetHeroStatByTowerDamage(towerDamage).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroStatResource(items[i]).ToModel();
            //    }
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<List<HeroStat>>(HttpStatusCode.OK, items);
        }
    }
}
