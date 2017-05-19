using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.Hero;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class HeroController : ApiController
    {
        HeroRepository heroRepository = new HeroRepository();

        // GET: api/Hero
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroRepository.GetAll().Select(o => new HeroResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //List<Hero> items;
            //try
            //{
            //    items = heroRepository.GetAll().ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroResource(items[i]).ToModel();
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
            //return Request.CreateResponse<IEnumerable<Hero>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new HeroResource(heroRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
            //Hero item;
            //try
            //{
            //    item = new HeroResource(heroRepository.Get(id)).ToModel();
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<Hero>(HttpStatusCode.OK, item);
        }

        //POST api/hero
        public HttpResponseMessage Post([FromBody]HeroResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new HeroResource(heroRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
            //try
            //{
            //    value = new HeroResource(heroRepository.Insert(value.ToModel()));
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<HeroResource>(HttpStatusCode.OK, value);
        }

        //PUT api/hero/5
        public HttpResponseMessage Put(int id, [FromBody]HeroResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new HeroResource(heroRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //try
            //{
            //    value = new HeroResource(heroRepository.Update(id, value.ToModel()));
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            //}
            //finally
            //{
            //    NpgsqlHelper.Connection.Close();
            //}
            //return Request.CreateResponse<HeroResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/hero/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                heroRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //try
            //{
            //    heroRepository.Delete(id);
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

        // Get api/hero?name=Pudge
        public HttpResponseMessage GetHeroByName(string name)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroRepository.GetHeroByName(name).Select(o => new HeroResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //List<Hero> items;
            //try
            //{
            //    items = heroRepository.GetHeroByName(name).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroResource(items[i]).ToModel();
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
            //return Request.CreateResponse<List<Hero>>(HttpStatusCode.OK, items);
        }

        // Get api/hero?hero_class=Agility
        public HttpResponseMessage GetHeroByClass(string hero_class)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroRepository.GetHeroByClass(hero_class).Select(o => new HeroResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //List<Hero> items;
            //try
            //{
            //    items = heroRepository.GetHeroByClass(hero_class).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroResource(items[i]).ToModel();
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
            //return Request.CreateResponse<List<Hero>>(HttpStatusCode.OK, items);
        }

        // Get api/hero?hero_class=Initiator
        public HttpResponseMessage GetHeroByRole(string role)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, heroRepository.GetHeroByRole(role).Select(o => new HeroResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }

            //List<Hero> items;
            //try
            //{
            //    items = heroRepository.GetHeroByRole(role).ToList();
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        items[i] = new HeroResource(items[i]).ToModel();
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
            //return Request.CreateResponse<List<Hero>>(HttpStatusCode.OK, items);
        }
    }
}
